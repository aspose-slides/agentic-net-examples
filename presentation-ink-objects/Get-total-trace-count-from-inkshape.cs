// -----------------------------------------------------------------------------
// Example: Get total trace count from inkshape using C#
//
// Description:
// Demonstrates how to count the total number of trace objects contained in
// Ink shapes within a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, iterates through all slides and shapes, sums
// the trace counts of each Ink shape, outputs the result, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Inkshape, Trace Count, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate retrieval of total trace count from Ink shapes.
// - Build C# utilities for analyzing Ink annotations in presentations.
// - Integrate trace counting into PowerPoint workflow automation.
// - Validate Ink content before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                int totalTraceCount = 0;

                // Iterate through all slides and shapes to find Ink objects
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        Ink inkShape = shape as Ink;
                        if (inkShape != null)
                        {
                            IInkTrace[] traces = inkShape.Traces;
                            totalTraceCount += traces.Length;
                        }
                    }
                }

                Console.WriteLine("Total number of Trace objects in Ink shapes: " + totalTraceCount);

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported comment
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
