// -----------------------------------------------------------------------------
// Example: Replace rectangle fills with gray gradient using C#
// 
// Description:
// Demonstrates how to replace rectangle fills with a gray linear gradient in a PowerPoint presentation using Aspose.Slides for .NET. The program creates a sample PPTX if none exists, iterates through all slides and rectangle auto‑shapes, applies a gradient from light gray to dark gray, and saves the modified file. This automation can be used for bulk styling of presentations.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, rectangle gradient, fill replacement
// 
// Use Cases:
// - Automate visual style updates across multiple presentations.
// - Integrate presentation processing into .NET backend services.
// - Ensure consistent branding by applying gradient fills to shapes.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace ReplaceRectangleFillsWithGrayGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                Aspose.Slides.IAutoShape rectShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                rectShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectShape.FillFormat.SolidFillColor.Color = Color.White;
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                        {
                            autoShape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                            autoShape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                            autoShape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
                            autoShape.FillFormat.GradientFormat.GradientStops.Clear();
                            autoShape.FillFormat.GradientFormat.GradientStops.Add(0, Color.LightGray);
                            autoShape.FillFormat.GradientFormat.GradientStops.Add(100, Color.DarkGray);
                        }
                    }
                }
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
