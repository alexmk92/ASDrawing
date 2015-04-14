using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace ASDrawing
{
    /// <summary>
    /// Applies filters to input frame
    /// </summary>
    class ASFilter
    {
        /// <summary>
        /// Blurs the image based on the input variables, if no values for kernel and sigma are applied, then
        /// default values will be set by the method.
        /// </summary>
        /// <param name="inputFrame"></param>
        /// <param name="kernelSize"></param>
        /// <param name="sigma"></param>
        public void blur(Image<Bgr, Byte> inputFrame, SMOOTH_TYPE blurType, int kernelSize = 4, double sigma = 1.0)
        {
            var outputFrame = inputFrame;
            try
            {
                // Set default values for sigma and kernel size if anything goes wrong
                if (kernelSize <= 1 || sigma <= 1)
                {
                    kernelSize = 4;
                    sigma = 1.0;
                }
                    
                // Apply the smooth on the context
                CvInvoke.cvSmooth(inputFrame, outputFrame, blurType, kernelSize, kernelSize, sigma, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Write back to the output context
            inputFrame = outputFrame;
        }

        /// <summary>
        /// Given an input frame, apply a sobel filter to that frame and then write it back to the 
        /// input pointer.  Options for applying normal and threshold filters onto the image are available
        /// too.
        /// The image is converted to Grayscale to improve speed, RGB images obviously require *3 computation
        /// to process on each channel
        /// 
        /// aperture must be 1, 3, 5 or 7
        /// 
        /// NOTE: when sobel is enabled, we are still able to use the BLUR values from the previous script, I put this in as I thought it would be a nice addition.
        /// </summary>
        /// <param name="inputFrame"></param>
        /// <param name="aperture"></param>
        /// <param name="falloff"></param>
        /// <param name="normaliseImage"></param>
        /// <param name="applyThreshold"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public Image<Gray, float> sobel(Image<Bgr, Byte> inputFrame, int aperture, int threshold, int falloff, bool normaliseImage = false, bool applyThreshold = false, THRESH thresholdType = THRESH.CV_THRESH_BINARY)
        {
            // Get the grayscale representation of this image
            var grayscale = inputFrame.Convert<Gray, Byte>();

            // Get the X and Y derivatives for this image
            var sobelX = new Image<Gray, float>(grayscale.Size);
            var sobelY = new Image<Gray, float>(grayscale.Size);

            CvInvoke.cvSobel(grayscale, sobelX, 1, 0, aperture);
            CvInvoke.cvSobel(grayscale, sobelY, 0, 1, aperture);

            // If we get the absolute difference between sobelX and sobelY derivatives, then we get the normalised
            // version of this image.
            if (normaliseImage)
            {
                var norm = new Image<Gray, float>(grayscale.Size);
                CvInvoke.cvAbsDiff(sobelX, sobelY, norm);

                // Check if the script should end here, if we aren't applying the threshold too we will just return the
                // normalised image
                if (!applyThreshold)
                    return norm;

                // Find the threshold of the normalised image - this will provide a binary map to show the contours of the image
                var thresholImg = new Image<Gray, float>(grayscale.Size);
                CvInvoke.cvThreshold(norm, thresholImg, threshold, falloff, thresholdType);

                return thresholImg;
            }

            return sobelX;
        }
    }
}
