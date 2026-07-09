using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Determine slide background color (fallback to White)
                        System.Drawing.Color backgroundColor = System.Drawing.Color.White;
                        if (slide.Background.Type == Aspose.Slides.BackgroundType.OwnBackground &&
                            slide.Background.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                        {
                            backgroundColor = slide.Background.FillFormat.SolidFillColor.Color;
                        }

                        // Iterate over shapes and modify line shapes
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Line)
                            {
                                if (autoShape.LineFormat != null && autoShape.LineFormat.FillFormat != null)
                                {
                                    autoShape.LineFormat.FillFormat.SolidFillColor.Color = backgroundColor;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}