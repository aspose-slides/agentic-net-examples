using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomFramesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                pres = new Aspose.Slides.Presentation();
            }

            // -----------------------------------------------------------------
            // Create sections with colored background slides (demonstrates summary zoom)
            // -----------------------------------------------------------------
            string section1 = "Section 1";
            string section2 = "Section 2";
            string section3 = "Section 3";
            string section4 = "Section 4";

            // Section 1 slide
            Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.Red;
            Aspose.Slides.ISection sec1 = pres.Sections.AddSection(section1, slide);

            // Section 2 slide
            slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.Green;
            Aspose.Slides.ISection sec2 = pres.Sections.AddSection(section2, slide);

            // Section 3 slide
            slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;
            Aspose.Slides.ISection sec3 = pres.Sections.AddSection(section3, slide);

            // Section 4 slide
            slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;
            Aspose.Slides.ISection sec4 = pres.Sections.AddSection(section4, slide);

            // -----------------------------------------------------------------
            // Add a Summary Zoom frame to the first slide
            // -----------------------------------------------------------------
            Aspose.Slides.ISummaryZoomFrame summaryZoom = pres.Slides[0].Shapes.AddSummaryZoomFrame(50f, 50f, 500f, 250f);

            // -----------------------------------------------------------------
            // Add a regular Zoom frame linking to the second slide
            // -----------------------------------------------------------------
            Aspose.Slides.ISlide targetSlide = pres.Slides[1];
            Aspose.Slides.IZoomFrame zoomFrame = pres.Slides[0].Shapes.AddZoomFrame(150f, 20f, 100f, 100f, targetSlide);
            zoomFrame.ReturnToParent = true;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}