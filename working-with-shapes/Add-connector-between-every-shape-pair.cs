// -----------------------------------------------------------------------------
// Example: Add connector between every shape pair using C#
//
// Description:
// Demonstrates how to add a bent connector between every pair of shapes on each
// slide of a presentation using C# and Aspose.Slides for .NET. The example loads an
// existing PPTX file, iterates through all slides and shapes, creates connectors,
// connects them to the shape pairs, reroutes the connectors, and saves the result.
// This pattern can be used to automate diagram enhancements, validate shape
// relationships, or integrate connector logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Between, Every, 
// Shape, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding connectors between every shape pair in a presentation.
// - Build C# tools for PowerPoint presentation processing and diagram enrichment.
// - Generate or transform PPTX files with automated connector logic in .NET applications.
// - Validate shape relationships and connectivity before publishing or integration.
// -----------------------------------------------------------------------------

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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    IShapeCollection shapes = presentation.Slides[slideIndex].Shapes;
                    int shapeCount = shapes.Count;

                    // Add a connector between every pair of shapes
                    for (int i = 0; i < shapeCount; i++)
                    {
                        for (int j = i + 1; j < shapeCount; j++)
                        {
                            IShape shape1 = shapes[i];
                            IShape shape2 = shapes[j];

                            // Create a bent connector (default size, will be rerouted)
                            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                            connector.StartShapeConnectedTo = shape1;
                            connector.EndShapeConnectedTo = shape2;
                            connector.Reroute();
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
