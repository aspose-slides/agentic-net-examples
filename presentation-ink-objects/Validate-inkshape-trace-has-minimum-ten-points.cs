// -----------------------------------------------------------------------------
// Example: Validate inkshape trace has minimum ten points using C#
//
// Description:
// Demonstrates how to validate inkshape trace has minimum ten points using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Inkshape, Trace, 
// Minimum, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validate inkshape trace has minimum ten points.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace InkValidationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    foreach (ISlide slide in pres.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            Ink inkShape = shape as Ink;
                            if (inkShape != null)
                            {
                                IInkTrace[] traces = inkShape.Traces;
                                foreach (IInkTrace trace in traces)
                                {
                                    if (trace.Points != null && trace.Points.Length < 10)
                                    {
                                        Console.WriteLine("Ink trace on slide {0} has fewer than 10 points.", slide.SlideNumber);
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation after validation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
