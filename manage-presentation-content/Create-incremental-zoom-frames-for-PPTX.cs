using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomFrameDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation or create a new one if the file does not exist
            Aspose.Slides.Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                pres = new Aspose.Slides.Presentation();
                // Ensure there are at least two slides for zoom linking
                Aspose.Slides.ISlide firstSlide = pres.Slides[0];
                Aspose.Slides.ISlide secondSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                // Optional: set simple backgrounds for visibility
                firstSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                firstSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                firstSlide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

                secondSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                secondSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                secondSlide.Background.FillFormat.SolidFillColor.Color = Color.LightCoral;
            }

            // Ensure there are at least three slides to demonstrate incremental zoom
            while (pres.Slides.Count < 3)
            {
                Aspose.Slides.ISlide newSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                newSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                newSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                newSlide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;
            }

            // Add zoom frames to the first slide linking to the second and third slides
            Aspose.Slides.ISlide baseSlide = pres.Slides[0];
            Aspose.Slides.ISlide targetSlide1 = pres.Slides[1];
            Aspose.Slides.ISlide targetSlide2 = pres.Slides[2];

            // First zoom frame
            Aspose.Slides.IZoomFrame zoomFrame1 = baseSlide.Shapes.AddZoomFrame(50f, 50f, 100f, 100f, targetSlide1);
            zoomFrame1.ReturnToParent = true;

            // Second zoom frame positioned below the first one
            Aspose.Slides.IZoomFrame zoomFrame2 = baseSlide.Shapes.AddZoomFrame(50f, 200f, 100f, 100f, targetSlide2);
            zoomFrame2.ReturnToParent = true;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}