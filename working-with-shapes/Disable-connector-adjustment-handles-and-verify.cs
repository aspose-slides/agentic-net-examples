// -----------------------------------------------------------------------------
// Example: Disable connector adjustment handles and verify using C#
// 
// Description:
// Demonstrates how to create a sample PowerPoint file, disable adjustment handles
// on connector shapes, and verify the setting using Aspose.Slides for .NET.
// The program processes PPTX files, modifies connector properties, and saves the
// result, providing console output for verification.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Disable connector adjustment handles
// 
// Use Cases:
// - Automate disabling of connector adjustment handles in presentations.
// - Validate connector properties programmatically.
// - Integrate PowerPoint manipulation into .NET automation workflows.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ConnectorAdjustmentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                if (!File.Exists(inputPath))
                {
                    // Create a sample presentation with a connector shape
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide firstSlide = samplePresentation.Slides[0];
                    Aspose.Slides.Connector sampleConnector = (Aspose.Slides.Connector)firstSlide.Shapes.AddConnector(Aspose.Slides.ShapeType.Line, 100, 100, 300, 100);
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                    Console.WriteLine("Sample input file created: " + inputPath);
                }

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                bool verificationFailed = false;

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        if (shape is Aspose.Slides.Connector)
                        {
                            Aspose.Slides.Connector connector = (Aspose.Slides.Connector)shape;
                            // Disable adjustment handles
                            connector.ConnectorLock.AdjustHandlesLocked = true;

                            // Verify that the handles are locked
                            bool isLocked = connector.ConnectorLock.AdjustHandlesLocked;
                            Console.WriteLine("Connector on slide " + slideIndex + ", shape " + shapeIndex + " adjustment handles locked: " + isLocked);
                            if (!isLocked)
                            {
                                verificationFailed = true;
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Modified presentation saved to: " + outputPath);

                if (verificationFailed)
                {
                    Console.WriteLine("Verification failed: some connectors were not locked.");
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("All connector adjustment handles successfully locked.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to unsupported format, you could add a comment here.
                // Format not supported.
                Environment.Exit(1);
            }
        }
    }
}
