// -----------------------------------------------------------------------------
// Example: Duplicate Ellipses with Offset in PPTX using C#
// 
// Description:
// Demonstrates how to duplicate every ellipse shape on each slide of a PPTX
// presentation, offsetting each duplicate by twenty points horizontally and
// vertically. The program creates a sample PPTX if none exists, processes the
// slides with Aspose.Slides for .NET, and saves the modified presentation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate Ellipse, Offset, Shape Processing
// 
// Use Cases:
// - Automate layout adjustments by duplicating shapes with a fixed offset.
// - Generate modified presentations for reporting or design workflows.
// - Validate shape positioning logic programmatically.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace Example
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Create a sample presentation if the input file does not exist
            if (!File.Exists(inputPath))
            {
                try
                {
                    using (Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation())
                    {
                        Aspose.Slides.ISlide blankSlide = samplePresentation.Slides.AddEmptySlide(samplePresentation.Slides[0].LayoutSlide);
                        blankSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 50f, 50f, 100f, 80f);
                        samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    return 1;
                }
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        List<Aspose.Slides.IAutoShape> ellipses = new List<Aspose.Slides.IAutoShape>();
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                ellipses.Add(autoShape);
                            }
                        }

                        foreach (Aspose.Slides.IAutoShape originalEllipse in ellipses)
                        {
                            float newX = originalEllipse.X + 20f;
                            float newY = originalEllipse.Y + 20f;
                            float width = originalEllipse.Width;
                            float height = originalEllipse.Height;
                            slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, newX, newY, width, height);
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing presentation: " + ex.Message);
                return 1;
            }

            Console.WriteLine("Processing completed successfully. Output saved to " + outputPath);
            return 0;
        }
    }
}
