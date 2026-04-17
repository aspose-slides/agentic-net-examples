using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideBackgroundReplace
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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.IBackgroundEffectiveData effectiveBackground = presentation.Slides[i].Background.GetEffective();

                    if (effectiveBackground.FillFormat.FillType == Aspose.Slides.FillType.Picture)
                    {
                        // Replace picture fill with solid color (Blue)
                        presentation.Slides[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                        presentation.Slides[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}