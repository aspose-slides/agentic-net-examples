using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetEllipseLineWidth
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

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate over all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate over all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Cast to IAutoShape to access ShapeType
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                // Ensure the shape has a line format and set its width to 2 points
                                if (autoShape.LineFormat != null)
                                {
                                    autoShape.LineFormat.Width = 2f;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}