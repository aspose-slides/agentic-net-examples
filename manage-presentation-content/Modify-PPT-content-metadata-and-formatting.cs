using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
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

        // Modify built‑in document properties
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
        docProps.Author = "John Doe";
        docProps.Title = "Updated Presentation";
        docProps.Subject = "Demo";
        docProps.Comments = "Modified using Aspose.Slides";
        docProps.Manager = "Jane Smith";

        // Add a new empty slide based on the layout of the first slide
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Change the background color of the new slide
        newSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        newSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        newSlide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();

        Console.WriteLine("Presentation saved to: " + outputPath);
    }
}