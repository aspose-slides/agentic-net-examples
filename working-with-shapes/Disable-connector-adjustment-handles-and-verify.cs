using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through shapes on the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.Shape shape = (Aspose.Slides.Shape)slide.Shapes[i];
                if (shape is Aspose.Slides.Connector)
                {
                    Aspose.Slides.Connector connector = (Aspose.Slides.Connector)shape;

                    // Disable adjustment handles
                    connector.ConnectorLock.AdjustHandlesLocked = true;

                    // Verify that the handles are locked
                    bool isLocked = connector.ConnectorLock.AdjustHandlesLocked;
                    Console.WriteLine($"Connector at index {i} adjustment handles locked: {isLocked}");
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}