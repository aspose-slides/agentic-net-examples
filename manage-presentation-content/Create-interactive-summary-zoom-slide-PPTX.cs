using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SummaryZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Define section titles
            string section1 = "Section 1";
            string section2 = "Section 2";
            string section3 = "Section 3";
            string section4 = "Section 4";

            // First slide (already exists)
            ISlide slide = presentation.Slides[0];
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;
            presentation.Sections.AddSection(section1, slide);

            // Add additional slides with sections
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightGreen;
            presentation.Sections.AddSection(section2, slide);

            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightSalmon;
            presentation.Sections.AddSection(section3, slide);

            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightYellow;
            presentation.Sections.AddSection(section4, slide);

            // Add Summary Zoom frame to the first slide
            ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

            // Save the presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SummaryZoom.pptx");
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}