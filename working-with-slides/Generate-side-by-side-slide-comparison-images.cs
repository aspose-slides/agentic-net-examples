using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string firstPath = "First.pptx";
        string secondPath = "Second.pptx";
        string outputDir = "Output";

        try
        {
            if (!File.Exists(firstPath))
            {
                Console.WriteLine("File not found: " + firstPath);
                return;
            }
            if (!File.Exists(secondPath))
            {
                Console.WriteLine("File not found: " + secondPath);
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Presentation firstPres = new Presentation(firstPath))
            using (Presentation secondPres = new Presentation(secondPath))
            {
                int slideCount = Math.Min(firstPres.Slides.Count, secondPres.Slides.Count);
                for (int i = 0; i < slideCount; i++)
                {
                    ISlide firstSlide = firstPres.Slides[i];
                    ISlide secondSlide = secondPres.Slides[i];

                    using (IImage firstImage = firstSlide.GetImage(1f, 1f))
                    using (IImage secondImage = secondSlide.GetImage(1f, 1f))
                    {
                        using (MemoryStream firstStream = new MemoryStream())
                        using (MemoryStream secondStream = new MemoryStream())
                        {
                            firstImage.Save(firstStream, Aspose.Slides.ImageFormat.Png);
                            secondImage.Save(secondStream, Aspose.Slides.ImageFormat.Png);
                            using (Bitmap bmpFirst = new Bitmap(firstStream))
                            using (Bitmap bmpSecond = new Bitmap(secondStream))
                            {
                                int combinedWidth = bmpFirst.Width + bmpSecond.Width;
                                int combinedHeight = Math.Max(bmpFirst.Height, bmpSecond.Height);
                                using (Bitmap combined = new Bitmap(combinedWidth, combinedHeight))
                                {
                                    using (Graphics g = Graphics.FromImage(combined))
                                    {
                                        g.Clear(Color.White);
                                        g.DrawImage(bmpFirst, 0, 0);
                                        g.DrawImage(bmpSecond, bmpFirst.Width, 0);
                                    }
                                    string outPath = Path.Combine(outputDir, $"Slide_{i + 1}_Comparison.png");
                                    combined.Save(outPath, System.Drawing.Imaging.ImageFormat.Png);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("File format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}