using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Set a custom corporate background color on the first slide
                presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.FromArgb(0, 120, 215); // Corporate blue

                // Configure SWF export options
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                swfOptions.ViewerIncluded = true; // Include the integrated viewer

                // Save the presentation as SWF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}