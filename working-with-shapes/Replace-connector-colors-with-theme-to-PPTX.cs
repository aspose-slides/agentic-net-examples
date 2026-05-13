using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
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
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Use the first accent color from the master theme
                    Color themeColor = pres.MasterTheme.ColorScheme.Accent1.Color;

                    foreach (ISlide slide in pres.Slides)
                    {
                        for (int i = 0; i < slide.Shapes.Count; i++)
                        {
                            IShape shape = slide.Shapes[i];
                            // Identify connector shapes
                            if (shape is Aspose.Slides.Connector)
                            {
                                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                                shape.LineFormat.FillFormat.SolidFillColor.Color = themeColor;
                            }
                        }
                    }

                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}