// -----------------------------------------------------------------------------
// Example: Replace straight connector with curved preserve points using C#
//
// Description:
// Demonstrates how to replace straight connector with curved preserve points 
// using C# and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Straight, Connector, 
// Curved, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replace straight connector with curved preserve points.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate over all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        IShapeCollection shapes = slide.Shapes;

                        // Iterate over all shapes in the slide
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            IShape shape = shapes[shapeIndex];

                            // Process only connector shapes
                            if (shape is IConnector)
                            {
                                IConnector connector = (IConnector)shape;

                                // Identify straight connectors (using Line shape type)
                                if (connector.ShapeType == ShapeType.Line)
                                {
                                    // Change the connector to a bent (curved) type while preserving connections
                                    connector.ShapeType = ShapeType.BentConnector2;
                                    connector.Reroute();
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
