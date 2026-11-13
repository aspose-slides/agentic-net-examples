// -----------------------------------------------------------------------------
// Example: Log connector adjustment points from PPTX using C#
// 
// Description:
// Demonstrates how to enumerate connector shapes in a PPTX file and log the
// identifiers of connectors that contain more than two adjustment points using
// Aspose.Slides for .NET. The program creates a sample presentation if none is
// found, processes the file, outputs relevant connector information, and saves
// the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Adjustment Points, Shape Inspection
// 
// Use Cases:
// - Identify complex connectors in PowerPoint presentations.
// - Build diagnostic tools for PPTX validation.
// - Automate extraction of connector metadata in .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    // Create a blank slide (first slide already exists)
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                Environment.Exit(1);
            }

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
                            Console.WriteLine("Connector ID: " + shape.Name);
                        }
                    }
                }
            }

            try
            {
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
                presentation.Dispose();
                Environment.Exit(1);
            }

            presentation.Dispose();
        }
    }
}
