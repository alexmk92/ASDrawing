using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ASDrawing
{
    class ASFaceDetector
    {
        /// <summary>
        /// All member variables exist here, the haar cascade contains the viola-jones face 
        /// detection classifier, this will let us detect faces using the provided XML file 
        /// Haar works by matching faces against a provided training set
        /// 
        /// @NOTE: All XML Documents for training sets can be found at: 
        /// https://github.com/Itseez/opencv/tree/master/data/haarcascades
        /// this is the official github repository for opencv.
        /// </summary>
        private HaarCascade m_frontalHaar;
        private HaarCascade m_eyeHaar;

        /// <summary>
        /// Constructor for a new ASFaceDetector object.  This will instanciate a new Haar
        /// instance for recognising faces.
        /// 
        /// </summary>
        public ASFaceDetector()
        {
            // We use ../../ as we will be compiling from debug or release folder - this code is in the root level
            // so for simulating this is fine...
            m_frontalHaar = new HaarCascade("../../trainingSet/haarcascade_frontalface_alt_tree.xml");
            m_eyeHaar     = new HaarCascade("../../trainingSet/haarcascade_eye_tree_eyeglasses.xml");
        }

        /// <summary>
        /// Recives a pointer to the input frame and checks if any faces exist in the frame. If they do
        /// then a square is drawn with the color and frameweight specified
        /// This function will also draw any other miscellaneous components to the screen such as the
        /// eye prop
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="color"></param>
        /// <param name="frameWeight"></param>
        /// <param name="eyeSize"></param>
        /// <param name="eyeProp"></param>
        /// <param name="eyeColor"></param>
        public void DetectFace(Image<Bgr, byte> frame, Color color, bool drawBox, int frameWeight, Color eyeColor, int eyeSize, int eyeProp = 2)
        {
            // Convert the image to grayscale for image processing, must be grayscale as the XML file
            // works of intensity values, detecting from an 3 channel image will not work.
            Image<Gray, byte> gImage = frame.Convert<Gray, byte>();

            // Use the grayscale image to detect faces using the Haar algorithm against the training set.
            // @param HaarCascade - The training set (XML) to test for faces
            // @param double      - The scale factor 1.1 - 1.4, where 1.1 be slower but provide more accurate results, higher number 
            //                      results in less passes for faster computation
            // @param int         - The number of neighbours to sample - this will determine the probablility of being a face (0 to 4)
            //                      using a threshold of 0 will introduce artificates as the probability is lower, therefore more boxes are drawn
            // @param HAAR_DETECT - The detection type, pruning will tell the program to skip over areas that are unlikely to contain a face
            //                      making the computation much faster (this is done by interpolating values and seeing if they match
            // @param Size        - The size of the detection matrix, in the case below the algorithm will sample 25^2 pixels and see if
            //                      it contains a face, if it does then this will be appened to the faces matrix, that will be used to draw.
            //                      (note that this is the smallest region in which a face can be detected)
            if (drawBox)
            {
                var faces = gImage.DetectHaarCascade(m_frontalHaar, 1.1, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];

                // Traverse through the faces matrix and draw a box around each detected face. (this is drawn back to
                // the 3 channel image) - remember that the frame is a pointer to the input frame, therefore we can
                // draw directly to that frame from this context.
                foreach (var face in faces)
                {
                    frame.Draw(face.rect, new Bgr(color), frameWeight);
                }
            }

            // Check what type of eye we are going to draw - 0 means no eye, 1 means squsre, 2 means circle
            if (eyeProp == 0) return;

            // Now we perform the computation for the eyes, same principle as above...
            var eyes = gImage.DetectHaarCascade(m_eyeHaar, 1.1, 4, HAAR_DETECTION_TYPE.SCALE_IMAGE, new Size(25, 25))[0];

            foreach (var eye in eyes)
            {
                if (eyeProp == 1)
                    frame.Draw(eye.rect, new Bgr(eyeColor), eyeSize);
                else
                {
                    var center = new Point((int)Math.Abs(eye.rect.X*1.08) , (int)Math.Abs(eye.rect.Y*1.11));
                    var radius = eye.rect.Width / 2;
                    // draw the ellipsis
                    CvInvoke.cvCircle(frame, center, radius, new Bgr(eyeColor).MCvScalar, eyeSize, LINE_TYPE.CV_AA, 0);
                }

            }
        }
    }
}
