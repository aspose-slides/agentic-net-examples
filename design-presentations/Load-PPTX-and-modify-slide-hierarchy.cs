using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            Presentation presentation = new Presentation(inputPath);

            // Example edit: set the background of the first slide to a solid blue color
            presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}