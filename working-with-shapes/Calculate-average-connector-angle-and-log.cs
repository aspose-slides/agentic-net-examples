// -----------------------------------------------------------------------------
// Example: Calculate Average Connector Angle in PowerPoint Presentation
//
// Description:
// This console program loads a PPTX file (or creates one if missing), iterates
// through the shapes on the first slide to find connector shapes, computes each
// connector's direction angle based on its geometry, calculates the average
// angle, logs the result to the console, and saves the presentation. It shows
// how to perform geometric analysis with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, connector angle, average angle, slide geometry
//
// Use Cases:
// - Analyze connector orientations in diagram templates.
// - Generate consistency reports for presentation assets.
// - Integrate geometry validation into automated build pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation presCreate = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slideCreate = presCreate.Slides[0];
                Aspose.Slides.Connector demoConnector = (Aspose.Slides.Connector)slideCreate.Shapes.AddConnector(
                    Aspose.Slides.ShapeType.Line, 100, 100, 300, 200);
                // The connector will have Width = 200, Height = 100, resulting in a 26.565° angle.
                presCreate.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presCreate.Dispose();
                Console.WriteLine("Sample input file created: " + inputPath);
            }
            catch (Exception exCreate)
            {
                Console.WriteLine("Failed to create sample input file: " + exCreate.Message);
                Environment.Exit(1);
                return;
            }
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            if (pres.Slides.Count == 0)
            {
                Console.WriteLine("The presentation contains no slides.");
                pres.Dispose();
                Environment.Exit(1);
                return;
            }

            Aspose.Slides.ISlide slide = pres.Slides[0];
            double totalAngle = 0.0;
            int connectorCount = 0;

            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                if (shape is Aspose.Slides.Connector)
                {
                    Aspose.Slides.Connector connector = (Aspose.Slides.Connector)shape;
                    double width = (double)connector.Width;
                    double height = (double)connector.Height;
                    double angle = Math.Atan2(height, width) * (180.0 / Math.PI);
                    totalAngle += angle;
                    connectorCount++;
                }
            }

            if (connectorCount > 0)
            {
                double averageAngle = totalAngle / connectorCount;
                Console.WriteLine("Average connector angle: " + averageAngle);
            }
            else
            {
                Console.WriteLine("No connectors found on the first slide.");
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
            Console.WriteLine("Presentation saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
