using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBitmapExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through each slide and save its bitmap as PNG
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                Aspose.Slides.IImage bitmap = slide.GetImage();
                string outputFile = $"slide_{index}.png";
                bitmap.Save(outputFile, ImageFormat.Png);
                // Dispose the bitmap after saving
                bitmap.Dispose();
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}