using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailTests
{
    class Program
    {
        static void Main()
        {
            string inputPath = "sample.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);
                ISlide slide = presentation.Slides[0];

                float[] scaleXValues = new float[] { 0.5f, 1.0f, 2.0f };
                float[] scaleYValues = new float[] { 0.5f, 1.0f, 2.0f };

                foreach (float scaleX in scaleXValues)
                {
                    foreach (float scaleY in scaleYValues)
                    {
                        IImage image = slide.GetImage(scaleX, scaleY);
                        float expectedWidth = presentation.SlideSize.Size.Width * scaleX;
                        float expectedHeight = presentation.SlideSize.Size.Height * scaleY;

                        bool widthMatches = Math.Abs(image.Width - expectedWidth) < 0.01f;
                        bool heightMatches = Math.Abs(image.Height - expectedHeight) < 0.01f;

                        if (!widthMatches || !heightMatches)
                        {
                            Console.WriteLine("Thumbnail size mismatch for scaleX=" + scaleX + ", scaleY=" + scaleY + ". Expected (" + expectedWidth + "," + expectedHeight + ") but got (" + image.Width + "," + image.Height + ").");
                        }
                        else
                        {
                            Console.WriteLine("Thumbnail size correct for scaleX=" + scaleX + ", scaleY=" + scaleY + ".");
                        }

                        image.Dispose();
                    }
                }

                presentation.Save("output.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported.
            }
        }
    }
}