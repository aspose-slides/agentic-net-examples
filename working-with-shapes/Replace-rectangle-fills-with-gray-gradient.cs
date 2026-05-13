using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ReplaceRectangleFillsWithGrayGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Cast to IAutoShape to access ShapeType
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                        {
                            // Apply gradient fill (light gray to dark gray)
                            autoShape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                            autoShape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                            autoShape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
                            autoShape.FillFormat.GradientFormat.GradientStops.Add(0, Color.LightGray);
                            autoShape.FillFormat.GradientFormat.GradientStops.Add(100, Color.DarkGray);
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., loading errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}