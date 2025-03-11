using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba
{
    abstract class Filters
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceimage, int x, int y);
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        public Bitmap processImage(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        public Bitmap reverseprocessImage(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = sourceImage.Width-1; i >= 0; i--)
            {
                for (int j = sourceImage.Height - 1; j > 0; j--)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
    }

    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color sourceColor = sourceimage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }
    }

    class GreyFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {


            Color pixelColor = sourceimage.GetPixel(x, y);

            int intensity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
            Color grayColor = Color.FromArgb(intensity, intensity, intensity);

            return grayColor;
        }
    }

    class SepFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color pixelColor = sourceimage.GetPixel(x, y);
            int k = 20;

            int intensity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

            Color resultColor = Color.FromArgb(intensity + 2 * k < 0 ? 0 : (intensity + 2 * k > 255 ? 255 : intensity + 2 * k), intensity + (int)(0.5 * k) < 0 ? 0 : (intensity + (int)(0.5 * k) > 255 ? 255 : intensity + (int)(0.5 * k)), intensity - k < 0 ? 0 : (intensity - k > 255 ? 255 : intensity - k));

            return resultColor;
        }

    }

    class YarkFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color pixelColor = sourceimage.GetPixel(x, y);

            Color resultColor = Color.FromArgb(pixelColor.R + 20 < 0 ? 0 : (pixelColor.R + 20 > 255 ? 255 : pixelColor.R + 20), pixelColor.G + 20 < 0 ? 0 : (pixelColor.G + 20 > 255 ? 255 : pixelColor.G +20), pixelColor.B + 20 < 0 ? 0 : (pixelColor.B + 20 > 255 ? 255 : pixelColor.B + 20));

            return resultColor;
        }

    }

    class Sdvig : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color resultColor;

            if(x < sourceimage.Width - 50)
                resultColor = sourceimage.GetPixel(x + 50, y);
            else
                resultColor = Color.FromArgb(255, 255, 255);

            return resultColor;
        }
    }

    class SdvigRev : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color resultColor;

            if (x >= 50)
                resultColor = sourceimage.GetPixel(x - 50, y);
            else
                resultColor = Color.FromArgb(0, 0, 0);

            return (resultColor);
        }
    }
}