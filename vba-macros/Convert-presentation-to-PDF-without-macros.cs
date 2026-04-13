using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input macro‑enabled presentation path
        string inputPath = "macro_enabled.pptm";
        // Output PDF path
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation without embedded binary objects (macros, OLE, etc.)
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Save as PDF; macros are omitted due to load options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}