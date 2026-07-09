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

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            if (shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;
                                if (autoShape.ShapeType == ShapeType.Ellipse)
                                {
                                    IFillFormat fill = autoShape.FillFormat;
                                    if (fill != null && fill.FillType == FillType.Solid)
                                    {
                                        System.Drawing.Color originalColor = fill.SolidFillColor.Color;
                                        // Consider a fill transparent if its alpha is less than fully opaque
                                        if (originalColor.A < 255)
                                        {
                                            System.Drawing.Color newColor = System.Drawing.Color.FromArgb(128, originalColor.R, originalColor.G, originalColor.B);
                                            fill.SolidFillColor.Color = newColor;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}