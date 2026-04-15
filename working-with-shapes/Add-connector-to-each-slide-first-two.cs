using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConnectorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // The file format is not supported.
                return;
            }

            // Iterate through each slide
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                IShapeCollection shapes = slide.Shapes;

                // Ensure there are at least two shapes to connect
                if (shapes.Count >= 2)
                {
                    // Get the first two shapes
                    IShape firstShape = shapes[0];
                    IShape secondShape = shapes[1];

                    // Add a bent connector
                    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                    // Connect the shapes
                    connector.StartShapeConnectedTo = firstShape;
                    connector.EndShapeConnectedTo = secondShape;

                    // Reroute the connector to the shortest path
                    connector.Reroute();
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();

            Console.WriteLine("Processing completed. Output saved to: " + outputPath);
        }
    }
}