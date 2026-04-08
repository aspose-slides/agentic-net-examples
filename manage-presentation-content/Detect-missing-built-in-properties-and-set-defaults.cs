using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            // Create a new presentation if the input file does not exist
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Populate built‑in properties with default values
                presentation.DocumentProperties.ClearBuiltInProperties();

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
                return;
            }
        }

        try
        {
            // Load the existing presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Populate built‑in properties with default values
                presentation.DocumentProperties.ClearBuiltInProperties();

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported (PPTX)
            Console.WriteLine("PPTX format not supported: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Format not supported (PPT)
            Console.WriteLine("PPT format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}