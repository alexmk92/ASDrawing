using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace ASDrawing
{
    /// <summary>
    /// Represent the main window object, this will delegate calls
    /// to the ASCamera object to handle any processing
    /// </summary>
    public partial class ASWindow : Form
    {
        private ASCamera       m_camera;
        private Color          m_color;
        private Color          m_eyeColor;
        private int            m_boxWeight;
        private int            m_eyeSize;
        private int            m_apertureSize;
        private FLIP           m_orientation;
        private SMOOTH_TYPE    m_blurType;
        private THRESH         m_threshType;
        private bool           m_isBlurring;
        private bool           m_isSobel;
        private bool           m_thresholdChecked;
        private bool           m_normaliseChecked;
        private int            m_thresholdValue;
        private int            m_falloffValue;
        private int            m_eyeType;

        /// <summary>
        /// Initialises the window and creates a new ASCamera object
        /// that points to this window object.
        /// </summary>
        public ASWindow()
        {
            InitializeComponent();

            // Set default sizes
            m_boxWeight = 3;
            m_eyeSize = 3;

            // Build the camera (rendering device)
            m_camera = new ASCamera(this);

            // Default to red color
            colorSelect.SelectedIndex = 1;
            selectBlur.SelectedIndex = 0;
            selectType.SelectedIndex = 0;
            eyePropSelect.SelectedIndex = 2;
            eyeColor.SelectedIndex = 5;

            m_thresholdValue = thresholdValue.Value;
            m_falloffValue = scrollFalloff.Value;

            // Initialise the camera capture
            m_camera.ReadFrameIntoBuffer(this, null);
        }

        /// <summary>
        /// Public interface to set the state of the capture button
        /// </summary>
        /// <returns></returns>
        public void setCaptureText(string state)
        {
            if (state == null) throw new ArgumentNullException("state");
            btnCapture.Text = state;
        }

        /// <summary>
        /// Set the value of sigma
        /// </summary>
        /// <param name="value"></param>
        public void setSigmaText(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            lblSigma.Text = value;
        }

        /// <summary>
        /// Set the value of sigma
        /// </summary>
        /// <param name="value"></param>
        public void setKernelSizeText(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            lblKernel.Text = value;
        }

        /// <summary>
        /// Sets 
        /// </summary>
        /// <param name="img"></param>
        public ImageBox GetRenderContext()
        {
            return CameraImageBox;
        }

        /// <summary>
        /// Delegates a capture request to the ASCameras object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapture_Click(object sender, EventArgs e)
        {
            m_camera.ReadFrameIntoBuffer(sender, e);
        }

        /// <summary>
        /// Sets the color of the eye prop to be drawn to the frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eyePropSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_eyeType = eyePropSelect.SelectedIndex;
            SetDelegate();
        }

        /// <summary>
        /// Sets the color of the box to be drawn to the frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var color = colorSelect.SelectedItem.ToString().ToUpper();

            switch (color)
            {
                case "RED":
                    m_color = Color.Red;
                    break;
                case "GREEN":
                    m_color = Color.Green;
                    break;
                case "BLUE":
                    m_color = Color.Blue;
                    break;
                case "YELLOW":
                    m_color = Color.Yellow;
                    break;
                default:
                    m_color = Color.Transparent;
                    break;
            }
            SetDelegate();
        }

        /// <summary>
        /// Sets the new eye color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eyeColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var color = eyeColor.SelectedItem.ToString().ToUpper();

            switch (color)
            {
                case "RED":
                    m_eyeColor = Color.Red;
                    break;
                case "GREEN":
                    m_eyeColor = Color.Green;
                    break;
                case "BLUE":
                    m_eyeColor = Color.Blue;
                    break;
                case "YELLOW":
                    m_eyeColor = Color.Yellow;
                    break;
                case "WHITE":
                    m_eyeColor = Color.White;
                    break;
                default:
                    m_eyeColor = Color.Transparent;
                    break;
            }
            SetDelegate();
        }

        /// <summary>
        /// Sets the weight of the box in px, updates the label on the GUI
        /// to reflect the changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boxWeight_Scroll(object sender, ScrollEventArgs e)
        {
            m_boxWeight       = boxWeight.Value;
            lblBoxWeight.Text = m_boxWeight.ToString();

            SetDelegate();
        }

        /// <summary>
        /// Set the eye size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrollEyeSize_Scroll(object sender, ScrollEventArgs e)
        {
            m_eyeSize = scrollEyeSize.Value;
            lblEyeSize.Text = m_eyeSize.ToString();

            SetDelegate();
        }

        /// <summary>
        /// Update the kernel size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kernalSize_Scroll(object sender, ScrollEventArgs e)
        {
            lblKernel.Text = kernalSize.Value.ToString();
            SetDelegate();
        }

        /// <summary>
        /// Update the value of sigma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sigmaSize_Scroll(object sender, ScrollEventArgs e)
        {
            lblSigma.Text = sigmaSize.Value.ToString();
            SetDelegate();
        }


        /// <summary>
        /// Flips image horizontally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlipH_Click(object sender, EventArgs e)
        {
            m_orientation = FLIP.HORIZONTAL;
            SetDelegate(true);
        }

        /// <summary>
        /// Flips image vertically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlipV_Click(object sender, EventArgs e)
        {
            m_orientation = FLIP.VERTICAL;
            SetDelegate(true);
        }

        /// <summary>
        /// Sets the delegates parameters to perform drawing
        /// </summary>
        private void SetDelegate(bool settingOrientation = false)
        {
            m_camera.UpdateParameters(m_boxWeight, m_color, m_eyeSize, m_eyeColor, m_eyeType, m_orientation, settingOrientation, m_blurType, m_isBlurring, m_isSobel, kernalSize.Value, sigmaSize.Value, m_apertureSize, m_normaliseChecked, m_thresholdChecked, m_thresholdValue, m_falloffValue, m_threshType);
        }

        /// <summary>
        /// Calls the rendering device and requests it to save the current frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                m_camera.SaveFrame();
                MessageBox.Show("Success, the image was saved in the images directory of this application.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, there was a problem when saving the image: " + ex.Message);
            }
        }

        /// <summary>
        /// Sets the state of the blur controls
        /// </summary>
        /// <param name="enabled"></param>
        private void SetBlurControls(bool enabled)
        {
            sigmaSize.Enabled = enabled;
            kernalSize.Enabled = enabled;

            m_isBlurring = enabled;
        }

        /// <summary>
        /// Sets the state of the sobel control filters
        /// </summary>
        /// <param name="enabled"></param>
        private void SetSobelControls(bool enabled)
        {
            //Default these to false
            SetThresholdControls(false);

            // Set the rest of the controls
            chkNormalise.Enabled = enabled;
            chkNormalise.Visible = enabled;
            chkThreshold.Enabled = enabled;
            chkThreshold.Visible = enabled;
            scrollAperture.Visible = enabled;
            scrollAperture.Enabled = enabled;
            lblAperture.Visible = enabled;
            lblApertureTitle.Visible = enabled;

            // Override threshold controls
            if (!m_normaliseChecked)
            {
                m_thresholdChecked = false;
                chkThreshold.Enabled = false;
                chkThreshold.Checked = false;
            }
        }

        /// <summary>
        /// Sets the blur value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectBlur_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the blur type
            var currBlur = selectBlur.SelectedItem.ToString().ToUpper();

            // by default we don't use sobel
            m_isSobel = false;
            SetSobelControls(false);

            // Update the blur flag
            switch (currBlur)
            {
                case "GAUSSIAN":
                    m_blurType = SMOOTH_TYPE.CV_GAUSSIAN;
                    SetBlurControls(true);
                    break;
                case "MEDIAN":
                    m_blurType = SMOOTH_TYPE.CV_MEDIAN;
                    SetBlurControls(true);
                    break;
                case "BILATERAL":
                    m_blurType = SMOOTH_TYPE.CV_BILATERAL;
                    SetBlurControls(true);
                    break;
                case "BOX":
                    m_blurType = SMOOTH_TYPE.CV_BLUR;
                    SetBlurControls(true);
                    break;
                case "SOBEL":
                    m_isSobel = true;
                    SetSobelControls(m_isSobel);
                    break;
                default:
                    SetBlurControls(false);
                    break;
            }

            SetDelegate();
        }

        /// <summary>
        /// Set the aperture value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrollAperture_Scroll(object sender, ScrollEventArgs e)
        {
            var val = Math.Abs((scrollAperture.Value/10) + 1);
            if (val >= 0 && val <= 2)
                val = 1;
            else if (val >= 3 && val <= 4)
                val = 3;
            else if (val >= 5 && val <= 6)
                val = 5;
            else if (val >= 6 && val <= 8)
                val = 7;

            m_apertureSize = val;
            lblAperture.Text = val.ToString();
            SetDelegate();
        }

        /// <summary>
        /// Tells the renderer we wish to normalise this sobel image too
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkNormalise_CheckedChanged(object sender, EventArgs e)
        {
            m_normaliseChecked = chkNormalise.Checked;
            if (m_normaliseChecked)
            {
                chkThreshold.Enabled = true;
            }
            else
            {
                chkThreshold.Enabled = false;
                chkThreshold.Checked = false;
            }
            SetDelegate();
        }

        /// <summary>
        /// Tells the render we wish to apply the threshold to this image too
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkThreshold_CheckedChanged(object sender, EventArgs e)
        {
            // Threshold can only be on if normalise is
            if (!m_normaliseChecked)
            {
                m_thresholdChecked = false;
                chkThreshold.Enabled = false;
                chkThreshold.Checked = false;
            }

            
            m_thresholdChecked = chkThreshold.Checked;
            SetThresholdControls(m_thresholdChecked);

            SetDelegate();
        }

        /// <summary>
        /// Sets the state of the threshold controls
        /// </summary>
        /// <param name="enabled"></param>
        private void SetThresholdControls(bool enabled)
        {
            lblThresholdVal.Visible = enabled;
            lblFalloffVal.Visible = enabled;
            lblFallofTitle.Visible = enabled;
            lblThresholdTitle.Visible = enabled;
            scrollFalloff.Visible = enabled;
            thresholdValue.Visible = enabled;
            lblThreshType.Visible = enabled;
            selectType.Visible = enabled;
        }

        /// <summary>
        /// Updates the falloff value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrollFalloff_Scroll(object sender, ScrollEventArgs e)
        {
            m_falloffValue = scrollFalloff.Value;
            lblFalloffVal.Text = m_falloffValue.ToString();
            SetDelegate();
        }

        /// <summary>
        /// Updates the threshold value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thresholdValue_Scroll(object sender, ScrollEventArgs e)
        {
            m_thresholdValue = thresholdValue.Value;
            lblThresholdVal.Text = m_thresholdValue.ToString();
            SetDelegate();
        }

        /// <summary>
        /// Sets the new threshold type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = selectType.SelectedItem.ToString().ToUpper();

            switch (type)
            {
                case "BINARY":
                    m_threshType = THRESH.CV_THRESH_BINARY;
                    break;
                case "INVERTED":
                    m_threshType = THRESH.CV_THRESH_BINARY_INV;
                    break;
                default:
                    m_threshType = THRESH.CV_THRESH_BINARY;
                    break;
            }

            SetDelegate();
        }
    }
}
