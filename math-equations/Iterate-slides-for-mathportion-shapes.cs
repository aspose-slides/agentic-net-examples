// -----------------------------------------------------------------------------
// Example: Locate MathPortion Shapes in PowerPoint Presentation using C#
// 
// Description:
// This console application loads a PPTX file, iterates through each slide and
// shape, and identifies portions that are MathPortion objects (equations). It
// uses Aspose.Slides for .NET to access slide content and reports the location
// of any found math portions. The presentation is saved after processing.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathPortion, equations, slide iteration
// 
// Use Cases:
// - Detect and list all equations in a corporate presentation for review.
// - Generate a report of slides containing mathematical content.
// - Prepare presentations for conversion where math objects need special handling.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathPortionFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            int slideIndex = 0;
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                slideIndex++;
                int shapeIndex = 0;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    shapeIndex++;
                    // Check if shape has a text frame (e.g., AutoShape)
                    Aspose.Slides.ITextFrame textFrame = null;
                    if (shape is Aspose.Slides.IAutoShape)
                    {
                        textFrame = ((Aspose.Slides.IAutoShape)shape).TextFrame;
                    }
                    else if (shape is Aspose.Slides.IGroupShape)
                    {
                        // Group shapes may contain nested shapes; skip for simplicity
                        continue;
                    }

                    if (textFrame == null)
                    {
                        continue;
                    }

                    foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                    {
                        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                        {
                            // Detect MathPortion via reflection to avoid missing namespace compile errors
                            Type portionType = portion.GetType();
                            if (portionType.FullName == "Aspose.Slides.Math.MathPortion")
                            {
                                Console.WriteLine($"MathPortion found on Slide {slideIndex}, Shape {shapeIndex} (Name: {shape.Name})");
                            }
                        }
                    }
                }
            }

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}
