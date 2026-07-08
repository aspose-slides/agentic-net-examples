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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                // Get the shape collection of the current slide
                Aspose.Slides.IShapeCollection shapes = pres.Slides[slideIndex].Shapes;
                int shapeCount = shapes.Count;

                // Add a connector between every pair of shapes
                for (int i = 0; i < shapeCount; i++)
                {
                    for (int j = i + 1; j < shapeCount; j++)
                    {
                        Aspose.Slides.IShape shape1 = shapes[i];
                        Aspose.Slides.IShape shape2 = shapes[j];

                        // Create a bent connector
                        Aspose.Slides.IConnector connector = shapes.AddConnector(
                            Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

                        // Connect the two shapes
                        connector.StartShapeConnectedTo = shape1;
                        connector.EndShapeConnectedTo = shape2;

                        // Adjust the connector path
                        connector.Reroute();
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported formats
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}