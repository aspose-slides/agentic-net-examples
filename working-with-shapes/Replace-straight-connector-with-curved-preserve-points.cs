using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate over all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        // Get the shapes collection of the current slide
                        IShapeCollection shapes = pres.Slides[slideIndex].Shapes;

                        // Iterate over all shapes in the collection
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            IShape shape = shapes[shapeIndex];

                            // Process only connector shapes
                            if (shape is IConnector)
                            {
                                IConnector connector = (IConnector)shape;

                                // Identify straight connectors (ShapeType.StraightConnector1)
                                if (connector.ShapeType == ShapeType.StraightConnector1)
                                {
                                    // Change the connector type to a curved connector
                                    connector.ShapeType = ShapeType.CurvedConnector2;

                                    // Reroute to adjust the path based on attachment points
                                    connector.Reroute();
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported: comment for clarity
                // Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}