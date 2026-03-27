using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SectionZoomFormatting
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            var presentation = new Presentation();

            // Define colors for consistent styling
            var fillColor = Color.CornflowerBlue;
            var lineColor = Color.DarkSlateGray;
            var lineWidth = 2.0f;

            // Add sections with a slide each and set background styling
            var sections = new ISection[3];
            for (int i = 0; i < 3; i++)
            {
                var slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                slide.Background.Type = BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = fillColor;

                var sectionTitle = $"Section {i + 1}";
                sections[i] = presentation.Sections.AddSection(sectionTitle, slide);
            }

            // Add Section Zoom frames to the first slide for each section
            var firstSlide = presentation.Slides[0];
            float x = 50f, y = 50f, width = 100f, height = 100f, offset = 120f;
            foreach (var section in sections)
            {
                var zoomFrame = firstSlide.Shapes.AddSectionZoomFrame(x, y, width, height, section);
                // Apply consistent visual formatting
                zoomFrame.LineFormat.Width = lineWidth;
                zoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
                zoomFrame.LineFormat.FillFormat.SolidFillColor.Color = lineColor;
                zoomFrame.FillFormat.FillType = FillType.Solid;
                zoomFrame.FillFormat.SolidFillColor.Color = fillColor;

                x += offset; // Position next zoom frame
            }

            // Save the presentation
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SectionZoomFormatted.pptx");
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}