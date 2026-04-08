using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideBackgroundChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    for (var i = 0; i < presentation.Slides.Count; i++)
                    {
                        // Set each slide's background to a custom RGB color (e.g., R=10, G=20, B=30)
                        presentation.Slides[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                        presentation.Slides[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.FromArgb(10, 20, 30);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}