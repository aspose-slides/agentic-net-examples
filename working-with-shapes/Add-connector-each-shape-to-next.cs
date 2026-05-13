using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectShapesBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ConnectedShapes.pptx";
            try
            {
                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide's shape collection
                IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Add sample shapes (three rectangles)
                IAutoShape rect1 = shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 50);
                IAutoShape rect2 = shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 100, 50);
                IAutoShape rect3 = shapes.AddAutoShape(ShapeType.Rectangle, 350, 250, 100, 50);

                // Connect each shape to the next one sequentially
                for (int i = 0; i < shapes.Count - 1; i++)
                {
                    // Add a bent connector (position and size are placeholders; they will be rerouted)
                    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                    connector.StartShapeConnectedTo = shapes[i];
                    connector.EndShapeConnectedTo = shapes[i + 1];
                    connector.Reroute();
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("File format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}