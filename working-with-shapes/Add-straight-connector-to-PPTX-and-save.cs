using System;
using System.IO;
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
            // Load the existing presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Get the shapes collection of the slide
            Aspose.Slides.IShapeCollection shapes = slide.Shapes;

            // Ensure there are at least two shapes to connect
            if (shapes.Count < 2)
            {
                Console.WriteLine("Not enough shapes to connect.");
                pres.Dispose();
                return;
            }

            // Retrieve the first two shapes
            Aspose.Slides.IShape shape1 = shapes[0];
            Aspose.Slides.IShape shape2 = shapes[1];

            // Add a straight connector (using BentConnector2 as the connector type)
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the shapes
            connector.StartShapeConnectedTo = shape1;
            connector.EndShapeConnectedTo = shape2;
            connector.Reroute();

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}