// -----------------------------------------------------------------------------
// Example: Add connector each shape to next using C#
//
// Description:
// Demonstrates how to add a connector between each consecutive shape in a
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds sample rectangle shapes, connects each shape to the next
// with bent connectors, and saves the result as a PPTX file. This pattern can be
// used to automate diagram creation or enhance slide layouts programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Shape, Sequential,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically link shapes in a flowchart or diagram.
// - Build C# utilities for generating connected shape layouts.
// - Integrate shape-connection logic into .NET PowerPoint automation tools.
// - Prepare PPTX files with predefined connectors for reporting or presentations.
// -----------------------------------------------------------------------------
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
