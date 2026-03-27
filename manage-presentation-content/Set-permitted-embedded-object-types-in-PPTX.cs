using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input file path and verify existence
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load presentation with option to delete all embedded binary objects (restrict embedded content)
        var loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DeleteEmbeddedBinaryObjects = true;
        var presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

        // Save the modified presentation
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();

        Console.WriteLine("Presentation saved with restricted embedded objects.");
    }
}