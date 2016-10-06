using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using ShelfInspectorImg.DTO;
using ShelfInspectorImg.Interfaces;

// TODO specialize parameter block by transformation to avoid constant unboxing object into int!!!


namespace ShelfInspectorImg.Transfromations
{
    public class GaborFilter : IImgTransform<Rgb, byte>
    {
        private const int GaborFilterParameterNumber = 6;

        public Image<Rgb, byte> PerformTransform(Image<Rgb, byte> emguImage, TransformationParameters parameters)
        {
            if (parameters.GetParametersCount() != GaborFilterParameterNumber)
                throw new ArgumentException("Wrong parameters number in GaborFilter!");

            var _params = parameters.Parameters;

            int kernelSize = (int)_params[0]; //>=0 & kernelSize % 2 == 0
            double sigma = (double) _params[1]; // (kernelSize == 0 ? 1 : kernelSize); // [0; kernelSize]
            sigma = (sigma > kernelSize) ? kernelSize : sigma;
            double theta = (double)_params[2]; // [0, PI]
            double lambda = (double)_params[3]; // [0; PI]
            double gamma = (double)_params[4]; // [0.2; 1]
            double psi = (double)_params[5]; // [0; PI]

            //Image<Gray, float> grayImage = emguImage.Convert<Gray, float>();
            ConvolutionKernelF kernel = MakeGaborKernel(kernelSize, sigma, theta, lambda, gamma, psi);
            CvInvoke.cvFilter2D(emguImage.Ptr, emguImage.Ptr, kernel, new Point(-1, -1));
            

            return emguImage.Convert<Rgb, byte>();
        }

        private ConvolutionKernelF MakeGaborKernel(int kernelSize,
                                                   double sigma,
                                                   double theta,
                                                   double lambda,
                                                   double gamma,
                                                   double psi)
        {
            ConvolutionKernelF kernel = new ConvolutionKernelF(kernelSize, kernelSize);

            int halfKernelSize = (kernelSize - 1) / 2;

            double doubleSigmaSqr = 2*sigma*sigma;
            double gammaSqr = gamma*gamma;
            double sineTheta = Math.Sin(theta);
            double cosineTheta = Math.Cos(theta);
            double k = 2*Math.PI/lambda;

            for (int x = -halfKernelSize, xk = 0; x <= halfKernelSize; ++x, ++xk)
            {
                for (int y = -halfKernelSize, yk = 0; y <= halfKernelSize; ++y, ++yk)
                {
                    double xTheta = x * cosineTheta + y * sineTheta;
                    double yTheta = -x * sineTheta + y * cosineTheta;
                    double exponent = Math.Exp(-(xTheta*xTheta + gammaSqr*yTheta*yTheta)/(doubleSigmaSqr));
                    double cosPart = (Math.Cos(k * xTheta  + psi));
                    double sinPart = (Math.Sin(k * xTheta  + psi));
                    kernel[xk, yk] = (float) Math.Sqrt(exponent*exponent*(cosPart*cosPart + sinPart*sinPart));
                }
            }

            return kernel;
        }
    }
}