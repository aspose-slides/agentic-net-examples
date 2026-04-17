using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        var inputPath = args.Length > 0 && !string.IsNullOrEmpty(args[0]) ? args[0] : "sample.pptx";

        // Check if file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Validate supported formats (PPT, PPTX, ODP)
        var extension = Path.GetExtension(inputPath).ToLowerInvariant();
        var isSupported = extension == ".ppt" || extension == ".pptx" || extension == ".odp";

        if (!isSupported)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format. Only PPT, PPTX, or ODP are allowed.");
            return;
        }

        try
        {
            // Load presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Prepare output path
            var directory = Path.GetDirectoryName(inputPath);
            var filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            var outputPath = Path.Combine(directory ?? "", filenameWithoutExt + "_out" + extension);

            // Save presentation (preserve original format)
            var saveFormat = extension == ".ppt"
                ? Aspose.Slides.Export.SaveFormat.Ppt
                : extension == ".pptx"
                    ? Aspose.Slides.Export.SaveFormat.Pptx
                    : Aspose.Slides.Export.SaveFormat.Odp;

            presentation.Save(outputPath, saveFormat);
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle any unexpected exceptions (e.g., loading errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}