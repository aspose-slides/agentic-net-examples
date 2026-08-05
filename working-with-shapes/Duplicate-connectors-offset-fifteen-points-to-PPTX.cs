// -----------------------------------------------------------------------------
// Example: Duplicate connectors offset fifteen points to PPTX using C#
//
// Description:
// Demonstrates how to duplicate connectors offset fifteen points to PPTX using 
// C# and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate, Connectors, Offset, 
// Fifteen, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate duplicate connectors offset fifteen points to PPTX.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorDuplicationExample
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    IShapeCollection shapes = slide.Shapes;

                    // Iterate through shapes collection
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.Shape shape = (Aspose.Slides.Shape)shapes[shapeIndex];

                        // Check if the shape is a connector
                        if (shape is Aspose.Slides.Connector)
                        {
                            Aspose.Slides.Connector originalConnector = (Aspose.Slides.Connector)shape;

                            // Create a duplicate connector with offset
                            IConnector duplicateConnector = shapes.AddConnector(
                                originalConnector.ShapeType,
                                originalConnector.X + 15f,
                                originalConnector.Y + 15f,
                                originalConnector.Width,
                                originalConnector.Height);

                            // Preserve connections
                            duplicateConnector.StartShapeConnectedTo = originalConnector.StartShapeConnectedTo;
                            duplicateConnector.EndShapeConnectedTo = originalConnector.EndShapeConnectedTo;
                            duplicateConnector.StartShapeConnectionSiteIndex = originalConnector.StartShapeConnectionSiteIndex;
                            duplicateConnector.EndShapeConnectionSiteIndex = originalConnector.EndShapeConnectionSiteIndex;

                            // Reroute the duplicated connector
                            duplicateConnector.Reroute();
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
