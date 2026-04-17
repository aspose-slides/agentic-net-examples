using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                // Create a new presentation if input file does not exist
                presentation = new Presentation();
            }

            // Set background color of every slide to light gray
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                presentation.Slides[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.LightGray;
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}