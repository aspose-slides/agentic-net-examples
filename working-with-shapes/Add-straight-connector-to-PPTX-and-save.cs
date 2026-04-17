using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddStraightConnector
{
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation from the specified file
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access the shape collection of the first slide
                    IShapeCollection shapes = presentation.Slides[0].Shapes;

                    // Add two sample shapes (ellipse and rectangle) to connect
                    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
                    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

                    // Add a straight connector (using BentConnector2 as the connector type)
                    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                    // Connect the shapes
                    connector.StartShapeConnectedTo = ellipse;
                    connector.EndShapeConnectedTo = rectangle;

                    // Reroute the connector to the shortest path
                    connector.Reroute();

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The PPTX file format is not supported: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The PPT file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}