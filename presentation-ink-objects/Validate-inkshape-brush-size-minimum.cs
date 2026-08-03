// -----------------------------------------------------------------------------
// Example: Validate inkshape brush size minimum using C#
//
// Description:
// Demonstrates how to validate and enforce a minimum brush size for Ink
// shapes in a PowerPoint presentation using Aspose.Slides for .NET. The
// example iterates through all slides, finds Ink shapes, checks the brush
// size of the first trace, and attempts to set a new size while ensuring it
// meets the minimum of 1 point. The presentation is then saved.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Inkshape, Brush,
// Size, Minimum, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure Ink shape brush sizes comply with corporate style guidelines.
// - Automate validation of Ink objects before publishing presentations.
// - Build .NET tools that enforce presentation standards for Ink strokes.
// - Detect and correct invalid brush sizes in existing PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesInkBrushSizeValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            if (shape is Aspose.Slides.Ink.Ink)
                            {
                                Aspose.Slides.Ink.Ink ink = (Aspose.Slides.Ink.Ink)shape;
                                Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;
                                if (traces != null && traces.Length > 0)
                                {
                                    Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;
                                    try
                                    {
                                        SizeF newSize = new SizeF(0.5f, 0.5f);
                                        if (newSize.Width < 1f || newSize.Height < 1f)
                                        {
                                            throw new ArgumentException("Brush size is below the allowed minimum of 1 point.");
                                        }
                                        brush.Size = newSize;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Error setting brush size on slide " + (slideIndex + 1) + ": " + ex.Message);
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
