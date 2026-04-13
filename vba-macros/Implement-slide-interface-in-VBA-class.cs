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
            // Create a new presentation when the input file does not exist
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            // Access the first slide by index
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            // Set background to a solid blue color
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        else
        {
            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                // Access the first slide by index
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                // Change background to a solid yellow‑green color
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.YellowGreen;
                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported: ex.Message
                // Handle other exceptions (e.g., external URL or web service errors)
            }
        }
    }
}