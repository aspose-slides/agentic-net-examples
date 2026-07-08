using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = null;
            try
            {
                if (File.Exists(inputPath))
                {
                    // Load existing presentation
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    // Create a new presentation
                    presentation = new Aspose.Slides.Presentation();
                }

                int slideIndex = 0;
                while (slideIndex < presentation.Slides.Count)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    int shapeIndex = 0;
                    while (shapeIndex < slide.Shapes.Count)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Determine fill type
                        Aspose.Slides.FillType fillType = Aspose.Slides.FillType.NotDefined;
                        if (shape.FillFormat != null)
                        {
                            fillType = shape.FillFormat.FillType;
                        }

                        // Determine line color
                        System.Drawing.Color lineColor = System.Drawing.Color.Empty;
                        if (shape.LineFormat != null && shape.LineFormat.FillFormat != null && shape.LineFormat.FillFormat.SolidFillColor != null)
                        {
                            lineColor = shape.LineFormat.FillFormat.SolidFillColor.Color;
                        }

                        Console.WriteLine("Slide {0}, Shape {1}: FillType = {2}, LineColor = {3}",
                            slideIndex + 1, shapeIndex + 1, fillType, lineColor);

                        shapeIndex++;
                    }
                    slideIndex++;
                }

                // Save the presentation before exit
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}