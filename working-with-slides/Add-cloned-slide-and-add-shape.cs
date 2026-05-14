using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide to clone
            Aspose.Slides.ISlide sourceSlide = pres.Slides[0];

            // Clone the slide to the end of the collection
            Aspose.Slides.ISlide clonedSlide = pres.Slides.AddClone(sourceSlide);

            // Add a new rectangle shape to the cloned slide for additional information
            clonedSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            pres.Dispose();
        }
        catch (Aspose.Slides.PptxEditException)
        {
            // Format not supported.
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}