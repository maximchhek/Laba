﻿using System;
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

            Color resultColor = Color.FromArgb(pixelColor.R + 2 * k, pixelColor.G + k / 2, pixelColor.B - 1 * k);

            return resultColor;
        }

    }
}
