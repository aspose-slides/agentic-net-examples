// -----------------------------------------------------------------------------
// Example: Set connector dash to dot in pptx using C#
//
// Description:
// Demonstrates how to set connector dash to dot in pptx using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Dash, Dot, 
// LineDashStyle, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set connector dash to dot in pptx.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.IShapeCollection shapes = presentation.Slides[slideIndex].Shapes;

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = shapes[shapeIndex];
                        Aspose.Slides.IConnector connector = shape as Aspose.Slides.IConnector;

                        // If the shape is a connector, set its line dash style to dot
                        if (connector != null && connector.LineFormat != null)
                        {
                            connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dot;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
