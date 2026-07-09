using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace BatchConnectorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported
                // (Comment: format not supported)
                return;
            }

            // Process first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IShapeCollection shapes = slide.Shapes;

            // Find the title placeholder shape
            Aspose.Slides.IShape titleShape = null;
            foreach (Aspose.Slides.IShape shape in shapes)
            {
                if (shape.Placeholder != null && shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
                {
                    titleShape = shape;
                    break;
                }
            }

            if (titleShape == null)
            {
                Console.WriteLine("Title placeholder not found on the slide.");
                presentation.Dispose();
                return;
            }

            // Add a connector from each shape to the title placeholder
            for (int i = 0; i < shapes.Count; i++)
            {
                Aspose.Slides.IShape currentShape = shapes[i];
                // Skip the title placeholder itself
                if (currentShape == titleShape)
                    continue;

                // Add connector (using rule connect-shapes-using-connectors)
                Aspose.Slides.IConnector connector = shapes.AddConnector(
                    Aspose.Slides.ShapeType.BentConnector2,
                    0, 0, 10, 10);

                connector.StartShapeConnectedTo = currentShape;
                connector.EndShapeConnectedTo = titleShape;
                connector.Reroute();
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose resources
            presentation.Dispose();
        }
    }
}