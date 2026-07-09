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
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there is a second slide (index 1)
                    if (presentation.Slides.Count > 1)
                    {
                        ISlide secondSlide = presentation.Slides[1];
                        foreach (IShape shape in secondSlide.Shapes)
                        {
                            if (shape.FillFormat != null && shape.FillFormat.FillType == FillType.Solid)
                            {
                                // Get existing solid fill color
                                Color baseColor = shape.FillFormat.SolidFillColor.Color;
                                // 40% transparency => alpha = 255 * (1 - 0.4) = 153
                                Color transparentColor = Color.FromArgb(153, baseColor);
                                shape.FillFormat.SolidFillColor.Color = transparentColor;
                            }
                        }
                    }

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}