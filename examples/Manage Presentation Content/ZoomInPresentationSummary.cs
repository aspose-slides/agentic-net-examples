using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationContentSummaryZoom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SummaryZoom.pptx");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // First slide – set background and create first section
            ISlide slide = presentation.Slides[0];
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.Red;
            ISection section1 = presentation.Sections.AddSection("Section 1", slide);

            // Second slide – set background and create second section
            ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide2.Background.Type = BackgroundType.OwnBackground;
            slide2.Background.FillFormat.FillType = FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = Color.Green;
            ISection section2 = presentation.Sections.AddSection("Section 2", slide2);

            // Third slide – set background and create third section
            ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide3.Background.Type = BackgroundType.OwnBackground;
            slide3.Background.FillFormat.FillType = FillType.Solid;
            slide3.Background.FillFormat.SolidFillColor.Color = Color.Blue;
            ISection section3 = presentation.Sections.AddSection("Section 3", slide3);

            // Fourth slide – set background and create fourth section
            ISlide slide4 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide4.Background.Type = BackgroundType.OwnBackground;
            slide4.Background.FillFormat.FillType = FillType.Solid;
            slide4.Background.FillFormat.SolidFillColor.Color = Color.Yellow;
            ISection section4 = presentation.Sections.AddSection("Section 4", slide4);

            // Add Summary Zoom frame to the first slide
            ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}