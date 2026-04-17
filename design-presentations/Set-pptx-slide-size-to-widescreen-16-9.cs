using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideSizeExample
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

                // Set slide size to widescreen 16:9 (e.g., 960x540 points) with EnsureFit scaling
                presentation.SlideSize.SetSize(960f, 540f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Change background of the first slide to blue
                presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the file format is not supported, handle accordingly
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}