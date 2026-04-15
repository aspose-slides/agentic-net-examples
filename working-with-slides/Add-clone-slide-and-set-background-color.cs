using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Clone the first slide to the end of the collection
            ISlideCollection slides = pres.Slides;
            ISlide clonedSlide = slides.AddClone(slides[0]);

            // Modify background of the cloned slide to highlight changes
            clonedSlide.Background.Type = BackgroundType.OwnBackground;
            clonedSlide.Background.FillFormat.FillType = FillType.Solid;
            clonedSlide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}