using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomControlExample
{
    class Program
    {
        static void Main()
        {
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            var pres = File.Exists(inputPath) ? new Presentation(inputPath) : new Presentation();

            using (pres)
            {
                // Add a new slide and configure its background
                var slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                slide.Background.FillFormat.FillType = FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
                slide.Background.Type = BackgroundType.OwnBackground;

                // Create a new section starting with the created slide
                var section = pres.Sections.AddSection("Section 1", slide);

                // Add a Section Zoom frame on the first slide linking to the new section
                var zoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(150, 20, 100, 100, section);

                // Set zoom (scale) for slide view and notes view
                pres.ViewProperties.SlideViewProperties.Scale = 150; // 150%
                pres.ViewProperties.NotesViewProperties.Scale = 150; // 150%

                // Save the presentation
                var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}