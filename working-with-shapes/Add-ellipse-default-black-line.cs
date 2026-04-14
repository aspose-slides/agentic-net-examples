using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEllipseDefaultBlackLine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a try‑catch to handle unsupported formats
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Comment: format not supported
                return;
            }

            // Iterate over all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                // Iterate over all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    // Cast to IAutoShape to access ShapeType and LineFormat
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                    {
                        // Ensure the shape has a LineFormat object
                        if (autoShape.LineFormat != null)
                        {
                            // Set a solid black line
                            autoShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            autoShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                            // Optionally set line width
                            autoShape.LineFormat.Width = 1.0f;
                        }
                    }
                }
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation object
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}