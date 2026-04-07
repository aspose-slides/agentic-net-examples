using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load options (no password required)
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();

            // Load the presentation from disk
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Access and modify built‑in document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
            docProps.Author = "Modified Author";
            docProps.Title = "Modified Title";
            docProps.Subject = "Modified Subject";

            // Example content modification: add a rectangle shape to the first slide
            presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50,   // X position
                50,   // Y position
                200,  // Width
                100   // Height
            );

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}