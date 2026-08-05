// -----------------------------------------------------------------------------
// Example: Log connector adjustment points from PPTX using C#
//
// Description:
// Demonstrates how to enumerate connectors in a PPTX file and log the IDs of
// connectors that have more than two adjustment points using Aspose.Slides for .NET.
// The example loads a presentation, inspects each shape, and outputs relevant
// connector information, then saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Adjustment Points, 
// Shape Inspection, Presentation Processing, Office Automation
//
// Use Cases:
// - Identify connectors with complex geometry in PowerPoint files.
// - Build diagnostics tools for PPTX validation.
// - Automate extraction of connector metadata in .NET applications.
// - Integrate connector analysis into larger presentation processing workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file
            string inputFile = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputFile);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Iterate through slides and shapes to find connectors with more than two adjustment points
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    if (shape is Aspose.Slides.Connector)
                    {
                        Aspose.Slides.Connector connector = (Aspose.Slides.Connector)shape;
                        if (connector.Adjustments.Count > 2)
                        {
                            Console.WriteLine("Connector ID: " + connector.OfficeInteropShapeId);
                        }
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
