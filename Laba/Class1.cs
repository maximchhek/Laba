using Laba;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Laba
{
    /// <summary>
    /// Абстрактный базовый класс для фильтров.
    /// </summary>
    abstract class Filters
    {
        /// <summary>
        /// Метод, который дочерний класс обязан переопределить, 
        /// чтобы определить, как рассчитывается цвет отдельного пикселя.
        /// </summary>
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        /// <summary>
        /// Вспомогательный метод для обрезки значений в диапазон [min, max].
        /// </summary>
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        /// <summary>
        /// Стандартная фильтрация изображения.
        /// Применяет calculateNewPixelColor к каждому пикселю.
        /// </summary>
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        /// <summary>
        /// Пример альтернативного прохода по пикселям (обратного).
        /// </summary>
        public Bitmap reverseprocessImage(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = sourceImage.Width - 1; i >= 0; i--)
            {
                for (int j = sourceImage.Height - 1; j >= 0; j--)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
    }

    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(
                255 - sourceColor.R,
                255 - sourceColor.G,
                255 - sourceColor.B);
        }
    }
    class GreyFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color pixelColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
            return Color.FromArgb(intensity, intensity, intensity);
        }
    }
    class SepFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color pixelColor = sourceImage.GetPixel(x, y);
            int k = 20;
            int intensity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

            int newR = Clamp(intensity + 2 * k, 0, 255);
            int newG = Clamp(intensity + (int)(0.5 * k), 0, 255);
            int newB = Clamp(intensity - k, 0, 255);

            return Color.FromArgb(newR, newG, newB);
        }
    }
    class YarkFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color pixelColor = sourceImage.GetPixel(x, y);
            int delta = 20;

            int newR = Clamp(pixelColor.R + delta, 0, 255);
            int newG = Clamp(pixelColor.G + delta, 0, 255);
            int newB = Clamp(pixelColor.B + delta, 0, 255);

            return Color.FromArgb(newR, newG, newB);
        }
    }
    class Sdvig : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int shift = 50;
            if (x < sourceImage.Width - shift)
                return sourceImage.GetPixel(x + shift, y);
            else
                return Color.FromArgb(255, 255, 255);
        }
    }
    class SdvigRev : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int shift = 50;
            if (x >= shift)
                return sourceImage.GetPixel(x - shift, y);
            else
                return Color.FromArgb(0, 0, 0);
        }
    }
    class Tisnenie : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            int[,] kernel = new int[3, 3]
            {
                { 0,  1,  0 },
                { -1, 0,  1 },
                { 0, -1,  0 }
            };

            float sumR = 0, sumG = 0, sumB = 0;
            for (int ky = -1; ky <= 1; ky++)
            {
                for (int kx = -1; kx <= 1; kx++)
                {
                    int new_x = x + kx;
                    int new_y = y + ky;

                    if (new_x < 0) new_x = 0;
                    else if (new_x == width) new_x = width - 1;

                    if (new_y < 0) new_y = 0;
                    else if (new_y == height) new_y = height - 1;

                    Color pixel = sourceImage.GetPixel(new_x, new_y);
                    sumR += pixel.R * kernel[kx + 1, ky + 1];
                    sumG += pixel.G * kernel[kx + 1, ky + 1];
                    sumB += pixel.B * kernel[kx + 1, ky + 1];
                }
            }

            sumR = Math.Max(0, Math.Min(sumR, 255));
            sumG = Math.Max(0, Math.Min(sumG, 255));
            sumB = Math.Max(0, Math.Min(sumB, 255));

            int intensity = (int)(0.299 * sumR + 0.587 * sumG + 0.114 * sumB);
            intensity = Math.Max(0, Math.Min(intensity, 255));

            intensity += 100;
            intensity = Math.Max(0, Math.Min(intensity, 255));

            return Color.FromArgb(intensity, intensity, intensity);
        }
    }
    class Rasmitie : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            int[,] kernel = {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1 }
            };

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;

            for (int dy = -radiusY; dy <= radiusY; ++dy)
            {
                for (int dx = -radiusX; dx <= radiusX; ++dx)
                {
                    int idX = x + dx, idY = y + dy;
                    if (idX < 0) idX = 0;
                    else if (idX > width - 1) idX = width - 1;

                    if (idY < 0) idY = 0;
                    else if (idY > height - 1) idY = height - 1;

                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    sumR += neighborColor.R * kernel[dx + radiusX, dy + radiusY];
                    sumG += neighborColor.G * kernel[dx + radiusX, dy + radiusY];
                    sumB += neighborColor.B * kernel[dx + radiusX, dy + radiusY];
                }
            }

            sumR = Math.Max(0, Math.Min(sumR / 9, 255));
            sumG = Math.Max(0, Math.Min(sumG / 9, 255));
            sumB = Math.Max(0, Math.Min(sumB / 9, 255));

            return Color.FromArgb(sumR, sumG, sumB);
        }
    }
    class Sharr : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            double[,] kernel_x = {
                { -3, -10, -3 },
                {  0,   0,  0 },
                {  3,  10,  3 }
            };
            double[,] kernel_y = {
                { -3,  0,  3 },
                { -10, 0, 10 },
                { -3,  0,  3 }
            };

            double sumRx = 0, sumGx = 0, sumBx = 0;
            double sumRy = 0, sumGy = 0, sumBy = 0;

            for (int dx = -1; dx <= 1; ++dx)
            {
                for (int dy = -1; dy <= 1; ++dy)
                {
                    int idX = x + dx, idY = y + dy;
                    if (idX < 0) idX = 0;
                    else if (idX >= width) idX = width - 1;

                    if (idY < 0) idY = 0;
                    else if (idY >= height) idY = height - 1;

                    Color pixel = sourceImage.GetPixel(idX, idY);
                    double R = pixel.R, G = pixel.G, B = pixel.B;

                    sumRx += R * kernel_x[dx + 1, dy + 1];
                    sumGx += G * kernel_x[dx + 1, dy + 1];
                    sumBx += B * kernel_x[dx + 1, dy + 1];

                    sumRy += R * kernel_y[dx + 1, dy + 1];
                    sumGy += G * kernel_y[dx + 1, dy + 1];
                    sumBy += B * kernel_y[dx + 1, dy + 1];
                }
            }

            int r = (int)Math.Sqrt(sumRx * sumRx + sumRy * sumRy);
            int g = (int)Math.Sqrt(sumGx * sumGx + sumGy * sumGy);
            int b = (int)Math.Sqrt(sumBx * sumBx + sumBy * sumBy);

            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return Color.FromArgb(r, g, b);
        }
    }
    class Sobel : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            double[,] kernel_x = {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 }
            };
            double[,] kernel_y = {
                { -1,  0,  1 },
                { -2,  0,  2 },
                { -1,  0,  1 }
            };

            double sumRx = 0, sumGx = 0, sumBx = 0;
            double sumRy = 0, sumGy = 0, sumBy = 0;

            for (int dx = -1; dx <= 1; ++dx)
            {
                for (int dy = -1; dy <= 1; ++dy)
                {
                    int idX = x + dx, idY = y + dy;
                    if (idX < 0) idX = 0;
                    else if (idX >= width) idX = width - 1;

                    if (idY < 0) idY = 0;
                    else if (idY >= height) idY = height - 1;

                    Color pixel = sourceImage.GetPixel(idX, idY);
                    double R = pixel.R, G = pixel.G, B = pixel.B;

                    sumRx += R * kernel_x[dx + 1, dy + 1];
                    sumGx += G * kernel_x[dx + 1, dy + 1];
                    sumBx += B * kernel_x[dx + 1, dy + 1];

                    sumRy += R * kernel_y[dx + 1, dy + 1];
                    sumGy += G * kernel_y[dx + 1, dy + 1];
                    sumBy += B * kernel_y[dx + 1, dy + 1];
                }
            }

            int r = (int)Math.Sqrt(sumRx * sumRx + sumRy * sumRy);
            int g = (int)Math.Sqrt(sumGx * sumGx + sumGy * sumGy);
            int b = (int)Math.Sqrt(sumBx * sumBx + sumBy * sumBy);

            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return Color.FromArgb(r, g, b);
        }
    }
    class Suzhenie : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            int[,] kernel = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            int minIntensity = 255;
            Color resColor = sourceImage.GetPixel(x, y);

            for (int dy = -radiusY; dy <= radiusY; ++dy)
            {
                for (int dx = -radiusX; dx <= radiusX; ++dx)
                {
                    int idX = x + dx, idY = y + dy;
                    if (idX < 0) idX = 0;
                    else if (idX >= width) idX = width - 1;

                    if (idY < 0) idY = 0;
                    else if (idY >= height) idY = height - 1;

                    if (kernel[dx + radiusX, dy + radiusY] == 1)
                    {
                        Color pixel = sourceImage.GetPixel(idX, idY);
                        int intensity = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

                        if (intensity < minIntensity)
                        {
                            minIntensity = intensity;
                            resColor = pixel;
                        }
                    }
                }
            }

            return resColor;
        }
    }
    class GrayWorld : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            double r = 0, g = 0, b = 0, mean = 0;

            // Считаем среднее значение всех пикселей
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Color pixel = sourceImage.GetPixel(i, j);
                    r += pixel.R;
                    g += pixel.G;
                    b += pixel.B;
                }
            }

            r /= (width * height);
            g /= (width * height);
            b /= (width * height);
            mean = (r + g + b) / 3;

            // Применяем на основе среднего значения
            Color pixelColor = sourceImage.GetPixel(x, y);
            int newR = Math.Max(0, Math.Min((int)(pixelColor.R * mean / r), 255));
            int newG = Math.Max(0, Math.Min(255, (int)(pixelColor.G * mean / g)));
            int newB = Math.Max(0, Math.Min(255, (int)(pixelColor.B * mean / b)));

            return Color.FromArgb(255, newR, newG, newB);
        }
    }
    class Autolevels : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            int minR = 255, maxR = 0;
            int minG = 255, maxG = 0;
            int minB = 255, maxB = 0;

            // Находим минимальные и максимальные значения для каждого канала
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Color pixel = sourceImage.GetPixel(i, j);

                    minR = Math.Min(minR, pixel.R);
                    maxR = Math.Max(maxR, pixel.R);
                    minG = Math.Min(minG, pixel.G);
                    maxG = Math.Max(maxG, pixel.G);
                    minB = Math.Min(minB, pixel.B);
                    maxB = Math.Max(maxB, pixel.B);
                }
            }

            // Нормализуем значения пикселей
            Color pixelColor = sourceImage.GetPixel(x, y);
            int newR = (int)((pixelColor.R - minR) * 255.0 / (maxR - minR));
            int newG = (int)((pixelColor.G - minG) * 255.0 / (maxG - minG));
            int newB = (int)((pixelColor.B - minB) * 255.0 / (maxB - minB));

            return Color.FromArgb(newR, newG, newB);
        }
    }
    class Rasshirenie : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            int[,] kernel = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            int r = 0;
            Color res = sourceImage.GetPixel(x, y);

            // Применяем фильтр, выбирая пиксель с максимальной интенсивностью
            for (int dy = -radiusY; dy <= radiusY; ++dy)
            {
                for (int dx = -radiusX; dx <= radiusX; ++dx)
                {
                    int idX = x + dx, idY = y + dy;
                    if (idX < 0) idX = 0;
                    else if (idX > width - 1) idX = width - 1;
                    if (idY < 0) idY = 0;
                    else if (idY > height - 1) idY = height - 1;

                    Color pixel = sourceImage.GetPixel(idX, idY);

                    int intensity = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                    if ((kernel[dx + radiusX, dy + radiusY] == 1) && (intensity > r))
                    {
                        r = intensity;
                        res = pixel;
                    }
                }
            }

            return res;
        }
    }
    class Median : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            int[] dots = new int[9];
            int[] points = new int[9];
            int size = 0;
            int radiusX = 1;
            int radiusY = 1;

            // Собираем интенсивности пикселей в окрестности
            for (int dx = -radiusX; dx <= radiusX; ++dx)
            {
                for (int dy = -radiusY; dy <= radiusY; ++dy)
                {
                    int idX = Math.Max(0, Math.Min(x + dx, width - 1));
                    int idY = Math.Max(0, Math.Min(y + dy, height - 1));
                    Color sourceColor = sourceImage.GetPixel(idX, idY);
                    int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
                    dots[size] = intensity;
                    points[size] = idX * height + idY;
                    size++;
                }
            }

            // Сортируем пиксели по интенсивности
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (dots[j] < dots[j + 1])
                    {
                        int tmp = dots[j];
                        int tmp1 = points[j];
                        dots[j] = dots[j + 1];
                        dots[j + 1] = tmp;
                        points[j] = points[j + 1];
                        points[j + 1] = tmp1;
                    }
                }
            }

            // Получаем медианный пиксель
            int newX = points[4] / height;
            int newY = points[4] % height;
            Color color = sourceImage.GetPixel(newX, newY);

            return color;
        }
    }
    class IdealOtrazh : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Находим максимальные значения для каждого канала
            int maxR = 0, maxG = 0, maxB = 0;
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Color pixel = sourceImage.GetPixel(i, j);

                    maxR = Math.Max(maxR, pixel.R);
                    maxG = Math.Max(maxG, pixel.G);
                    maxB = Math.Max(maxB, pixel.B);
                }
            }

            // Нормализуем значения пикселей, исходя из максимальных значений
            Color pixelColor = sourceImage.GetPixel(x, y);
            int newR = Math.Max(0, Math.Min(255, (int)(pixelColor.R * 255 / maxR)));
            int newG = Math.Max(0, Math.Min(255, (int)(pixelColor.G * 255 / maxG)));
            int newB = Math.Max(0, Math.Min(255, (int)(pixelColor.B * 255 / maxB)));

            return Color.FromArgb(255, newR, newG, newB);
        }
    }
}

