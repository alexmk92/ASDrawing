using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;

namespace ASDrawing
{
    class ASCamera
    {
        /// <summary>
        /// Private member variables
        /// </summary>
        private ASWindow m_window;
        private ASFilter m_filter;
        private Capture m_capture;
        private ASFaceDetector m_faceDetector;
        private Image<Bgr, byte> m_currentFrame;
        private THRESH m_threshType;
        private bool m_isCapturing;
        private bool m_isBlurring;
        private bool m_threshold;
        private bool m_normalise;
        private bool m_isSobel;
        private int m_thresholdVal;
        private int m_falloffVal;
        private Color m_color;
        private Color m_eyeColor;
        private int m_eyeSize;
        private int m_boxWeight;
        private int m_kernel;
        private int m_eyeType;
        private double m_sigma;
        private int m_aperture;
        private FLIP m_orientation;
        private SMOOTH_TYPE m_blurType;


        /// <summary>
        /// Initialises a new ASCamera object, this will also build a reference
        /// to the FaceDetection class so we can do any face processing
        /// </summary>
        /// <param name="w"></param>
        public ASCamera(ASWindow w)
        {
            m_faceDetector = new ASFaceDetector();
            m_filter       = new ASFilter();
            m_window       = w;
        }

        /// <summary>
        /// Reads a stream of images into the capture buffer from the camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReadFrameIntoBuffer(object sender, EventArgs e)
        {
            // Check if the capturer is available, if not create it now.
            if (m_capture == null)
            {
                try
                {
                    m_capture = new Capture();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }

            // Check if we are able to read from the input image stream
            if (m_capture == null) return;

            // If the camera is reading frames, then stop the capture - we can remove the RenderFrame function
            // from the application until we need to use it again.
            if (m_isCapturing)
            {
                m_window.setCaptureText("Start Capture");
                Application.Idle -= RenderFrame;
            }
            // The camera was previously idle, start reading new frames
            else
            {
                m_window.setCaptureText("Stop Capture");
                Application.Idle += RenderFrame;
            }

            m_isCapturing = !m_isCapturing;
        }

        /// <summary>
        /// Captures a frame from the Camera and saves it into an Image 
        /// frame - this will update the current frame context, which will
        /// allow us to handle events such as save.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void RenderFrame(object sender, EventArgs e)
        {
            m_currentFrame = m_capture.QueryFrame();
            var renderer = m_window.GetRenderContext();

            // Ensure we want to perform face detection...
            if (m_currentFrame != null && m_color != Color.Transparent)
                m_faceDetector.DetectFace(m_currentFrame, m_color, true, m_boxWeight, m_eyeColor, m_eyeSize, m_eyeType);
            if (m_currentFrame != null && m_color == Color.Transparent && m_eyeColor != Color.Transparent)
                m_faceDetector.DetectFace(m_currentFrame, m_color, false, m_boxWeight, m_eyeColor, m_eyeSize, m_eyeType);

            // Apply a blur to the 
            if(m_blurType != null && m_isBlurring)
                m_filter.blur(m_currentFrame, m_blurType, m_kernel, m_sigma);

            // Check if we need to render a 3 channel or single channel image
            if (m_isSobel)
            {
                renderer.Image = m_filter.sobel(m_currentFrame, m_aperture, m_thresholdVal, m_falloffVal, m_normalise, m_threshold, m_threshType).Flip(m_orientation);
            }
            else
                renderer.Image = m_currentFrame.Flip(m_orientation);
        }

        /// <summary>
        /// Saves the image as a file with a random string
        /// </summary>
        public void SaveFrame()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            // Only save if we have a valid context to save
            if (m_currentFrame != null)
                m_currentFrame.Save(@"../../images/" + result + ".jpg");
        }

        /// <summary>
        /// Updates the render parameters, such as the selected prop and 
        /// color of the box
        /// </summary>
        public void UpdateParameters(int boxWeight, Color c, int eyeSize, Color eyeColor, int eyeType, FLIP orientation, bool settingOrientation, SMOOTH_TYPE blurType, bool isBlurring, bool isSobel,
            int sigmaSize, int kernelSize, int apertureSize, bool normaliseChecked, bool thresholdChecked, int thresholdVal, int falloffVal, THRESH threshType)
        {
            // Set configuration parameters
            m_boxWeight = boxWeight;
            m_color = c;
            m_blurType = blurType;
            m_isBlurring = isBlurring;
            m_isSobel = isSobel;
            m_kernel = kernelSize;
            m_sigma = sigmaSize;
            m_falloffVal = falloffVal;
            m_thresholdVal = thresholdVal;
            m_aperture = apertureSize;
            m_normalise = normaliseChecked;
            m_threshold = thresholdChecked;
            m_threshType = threshType;
            m_eyeColor = eyeColor;
            m_eyeSize = eyeSize;
            m_eyeType = eyeType;

            // Check if the user wants to reset the orientation
            if (settingOrientation)
                m_orientation = (m_orientation == orientation) ? FLIP.NONE : orientation;
        }

        /// <summary>
        /// Clean up this object by disposing of any OpenCV objects we are using,
        /// this will allow the program to close safely
        /// </summary>
        private void Release()
        {
            if (m_capture != null)
                m_currentFrame.Dispose();
        }
    }
}
