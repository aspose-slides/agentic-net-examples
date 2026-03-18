using System;
using Aspose.Slides.Export;
using System.Drawing;

namespace ReadActiveSlideSize
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    System.Drawing.SizeF slideSize = presentation.SlideSize.Size;
                    float width = slideSize.Width;
                    float height = slideSize.Height;

                    Console.WriteLine("Slide Width: {0} points", width);
                    Console.WriteLine("Slide Height: {0} points", height);

                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}