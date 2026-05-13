using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];
                    IShapeCollection shapes = slide.Shapes;

                    // Ensure there are at least two shapes to connect
                    if (shapes.Count >= 2)
                    {
                        IShape firstShape = shapes[0];
                        IShape secondShape = shapes[1];

                        // Add a bent connector
                        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                        // Connect the first two shapes
                        connector.StartShapeConnectedTo = firstShape;
                        connector.EndShapeConnectedTo = secondShape;

                        // Reroute to get the shortest path
                        connector.Reroute();
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}