using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx"; // default placeholder
        }

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Get presentation info without loading the full presentation
            Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
            Aspose.Slides.LoadFormat loadFormat = info.LoadFormat;

            // Validate supported formats: PPT, PPTX, ODP
            bool supported = loadFormat == Aspose.Slides.LoadFormat.Ppt ||
                             loadFormat == Aspose.Slides.LoadFormat.Pptx ||
                             loadFormat == Aspose.Slides.LoadFormat.Odp;

            if (!supported)
            {
                // format not supported
                Console.WriteLine("File format not supported for conversion.");
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Define output path (convert to PPTX as an example)
                string outputPath = Path.Combine(
                    Path.GetDirectoryName(inputPath) ?? string.Empty,
                    Path.GetFileNameWithoutExtension(inputPath) + "_converted.pptx");

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Conversion completed: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}