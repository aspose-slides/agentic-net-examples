using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
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
            // Load the existing presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the shape collection of the first slide
                IShapeCollection shapes = pres.Slides[0].Shapes;

                // Ensure there are two shapes to connect; add them if necessary
                IAutoShape ellipse = null;
                IAutoShape rectangle = null;

                if (shapes.Count < 2)
                {
                    ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
                    rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
                }
                else
                {
                    ellipse = shapes[0] as IAutoShape;
                    rectangle = shapes[1] as IAutoShape;
                }

                // Add a straight connector (using BentConnector2 as the connector type)
                IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;
                connector.Reroute();

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported: comment added as per requirement
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}