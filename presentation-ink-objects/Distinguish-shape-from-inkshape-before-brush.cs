using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Iterate through all slides and shapes
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is an Ink shape
                    if (shape is Aspose.Slides.Ink.Ink)
                    {
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                        // Ink shapes have read‑only Traces; we can only read brush information
                        if (inkShape.Traces != null && inkShape.Traces.Length > 0)
                        {
                            Aspose.Slides.Ink.IInkBrush brush = inkShape.Traces[0].Brush;
                            Console.WriteLine("Ink shape found on slide {0}, shape {1}. InkEffect: {2}", slideIndex + 1, shapeIndex + 1, brush.InkEffect);
                            // Example: you could change rendering options, but not the brush itself because Traces is read‑only
                        }
                    }
                    else
                    {
                        // Regular shape handling – apply a simple fill color
                        Aspose.Slides.Shape regularShape = shape as Aspose.Slides.Shape;
                        if (regularShape != null && regularShape.FillFormat != null)
                        {
                            regularShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            regularShape.FillFormat.SolidFillColor.Color = Color.Blue;
                        }
                    }
                }
            }

            try
            {
                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}