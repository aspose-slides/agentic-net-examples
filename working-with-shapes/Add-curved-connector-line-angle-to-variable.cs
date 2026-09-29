// -----------------------------------------------------------------------------
// Example: Add Curved Connector and Retrieve Its Angle in Degrees Using Aspose.Slides
//
// Description:
// This console application creates or loads a PowerPoint presentation, adds a
// curved connector shape to the first slide, calculates the connector's line
// angle in degrees based on its geometry, stores the result in a variable, and
// saves the modified presentation as a PPTX file. It demonstrates how to work
// with Aspose.Slides for .NET to automate connector handling and geometry
// extraction.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, curved connector, line angle, geometry
//
// Use Cases:
// - Automate diagram creation with connectors in presentation generation pipelines.
// - Analyze connector orientation for layout validation or reporting.
// - Generate presentations with custom connector styling and geometry metadata.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesConnectorAngleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputPath = "input.pptx";
            const string outputPath = "output.pptx";

            try
            {
                Aspose.Slides.Presentation presentation;

                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a curved connector to the slide
                Aspose.Slides.IConnector connector = (Aspose.Slides.IConnector)slide.Shapes.AddConnector(
                    Aspose.Slides.ShapeType.CurvedConnector2,
                    100,   // X position
                    100,   // Y position
                    300,   // Width
                    200    // Height
                );

                // Calculate the angle of the connector line in degrees
                double angleRadians = Math.Atan2(connector.Height, connector.Width);
                double connectorAngleDegrees = angleRadians * (180.0 / Math.PI);

                Console.WriteLine("Connector angle (degrees): " + connectorAngleDegrees);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException nsEx)
            {
                // Handle unsupported file format scenarios
                Console.WriteLine("Format not supported: " + nsEx.Message);
            }
            catch (Exception ex)
            {
                // General exception handling for I/O, Aspose errors, etc.
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
