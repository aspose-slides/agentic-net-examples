using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath = "input.pptx";
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Define output file path with .odp extension
        string outputPath = Path.ChangeExtension(inputPath, ".odp");

        try
        {
            // Load presentation with embedded binary objects (including macros) removed
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Additional safety: remove VBA modules if any remain
                if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
                {
                    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
                }

                // Save as ODP format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}