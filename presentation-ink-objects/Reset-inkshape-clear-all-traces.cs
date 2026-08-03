// -----------------------------------------------------------------------------
// Example: Reset inkshape clear all traces using C#
//
// Description:
// Demonstrates how to remove all Ink shapes from a presentation, effectively
// clearing all ink traces, using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, iterates through its slides, deletes every Ink shape, and
// saves the result to a new file. This pattern can be used to reset ink
// annotations in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ink shape, Clear ink, Reset,
// Presentation processing, Office automation
//
// Use Cases:
// - Remove all ink annotations from a PowerPoint presentation.
// - Prepare PPTX files for redistribution without ink traces.
// - Automate cleanup of ink objects in batch processing pipelines.
// - Integrate ink reset functionality into .NET applications handling PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program.exe <input.pptx> <output.pptx>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Collect Ink shapes to remove (cannot modify collection while iterating)
                    List<Aspose.Slides.IShape> inksToRemove = new List<Aspose.Slides.IShape>();

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Cast shape to Ink; if successful, it's an Ink shape
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                        if (inkShape != null)
                        {
                            inksToRemove.Add(shape);
                        }
                    }

                    // Remove collected Ink shapes, effectively clearing all traces
                    foreach (Aspose.Slides.IShape inkShape in inksToRemove)
                    {
                        slide.Shapes.Remove(inkShape);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
