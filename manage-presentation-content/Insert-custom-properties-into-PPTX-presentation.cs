using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = "Data" + Path.DirectorySeparatorChar;
        string inputPath = dataDir + "input.pptx";
        string outputPath = dataDir + "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Add custom document properties
        documentProperties["CustomInt"] = 123;
        documentProperties["CustomString"] = "Hello World";
        documentProperties["CustomDate"] = DateTime.Now;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}