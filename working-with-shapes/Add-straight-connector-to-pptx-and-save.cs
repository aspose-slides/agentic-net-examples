// -----------------------------------------------------------------------------
// Example: Add Bent Connector to PPTX and Save Using C#
// 
// Description:
// Demonstrates how to add a bent connector between two shapes in a PPTX file
// using Aspose.Slides for .NET. The program creates a sample presentation if
// the input file is missing, adds the connector, and saves the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bent Connector, Connector, Save
// 
// Use Cases:
// - Automate adding a bent connector to existing presentations.
// - Build .NET tools for PowerPoint diagram enhancements.
// - Generate or modify PPTX files programmatically in batch processes.
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

        // Create a sample presentation if the input file does not exist
        if (!File.Exists(inputPath))
        {
            try
            {
                using (Aspose.Slides.Presentation presCreate = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slideCreate = presCreate.Slides[0];
                    Aspose.Slides.IShapeCollection shapesCreate = slideCreate.Shapes;

                    Aspose.Slides.IAutoShape ellipse = (Aspose.Slides.IAutoShape)shapesCreate.AddAutoShape(
                        Aspose.Slides.ShapeType.Ellipse, 50, 50, 100, 100);
                    Aspose.Slides.IAutoShape rectangle = (Aspose.Slides.IAutoShape)shapesCreate.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 300, 200, 120, 80);

                    presCreate.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                // Retrieve the first two AutoShape objects
                Aspose.Slides.IAutoShape shape1 = null;
                Aspose.Slides.IAutoShape shape2 = null;

                foreach (Aspose.Slides.IShape shape in shapes)
                {
                    if (shape is Aspose.Slides.IAutoShape)
                    {
                        if (shape1 == null)
                        {
                            shape1 = (Aspose.Slides.IAutoShape)shape;
                        }
                        else if (shape2 == null)
                        {
                            shape2 = (Aspose.Slides.IAutoShape)shape;
                        }

                        if (shape1 != null && shape2 != null)
                        {
                            break;
                        }
                    }
                }

                if (shape1 == null || shape2 == null)
                {
                    Console.WriteLine("Not enough shapes to connect.");
                    Environment.Exit(1);
                }

                // Add a bent connector and connect the two shapes
                Aspose.Slides.IConnector connector = (Aspose.Slides.IConnector)shapes.AddConnector(
                    Aspose.Slides.ShapeType.BentConnector2, 0, 0, 100, 100);
                connector.StartShapeConnectedTo = shape1;
                connector.EndShapeConnectedTo = shape2;

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
