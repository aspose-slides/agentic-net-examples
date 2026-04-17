using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideAsBmp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputBmpPath = "slide0.bmp";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
                // Scale factor to achieve 300 DPI (assuming base 96 DPI)
                float scale = 300f / 96f;
                Aspose.Slides.IImage image = pres.Slides[0].GetImage(scale, scale);
                image.Save(outputBmpPath, Aspose.Slides.ImageFormat.Bmp);
                image.Dispose();

                // Save presentation before exit
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}