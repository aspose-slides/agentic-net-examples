using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        var inputPath = args.Length > 0 ? args[0] : "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        var outputPath = Path.ChangeExtension(inputPath, ".odp");

        try
        {
            var loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            using (var presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Remove any VBA macros if present
                if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
                {
                    while (presentation.VbaProject.Modules.Count > 0)
                    {
                        presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
                    }
                }

                // Save as ODP
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}