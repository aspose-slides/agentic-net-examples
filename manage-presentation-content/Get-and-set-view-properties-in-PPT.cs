using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define the directory and file paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Modify view properties
        // Set grid spacing (points)
        presentation.ViewProperties.GridSpacing = 10.0f;
        // Set slide view zoom to 100%
        presentation.ViewProperties.SlideViewProperties.Scale = 100;
        // Set notes view zoom to 100%
        presentation.ViewProperties.NotesViewProperties.Scale = 100;
        // Enable display of comments
        presentation.ViewProperties.ShowComments = Aspose.Slides.NullableBool.True;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();

        Console.WriteLine("Presentation saved to: " + outputPath);
    }
}