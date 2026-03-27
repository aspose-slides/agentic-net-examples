using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SummaryZoomDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            string outputAfterRemovalPath = Path.Combine(Directory.GetCurrentDirectory(), "output_removed.pptx");

            // Load existing presentation if it exists, otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Create first slide and set its background
            ISlide slide = presentation.Slides[0];
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Add first section
            string section1Title = "Section 1";
            presentation.Sections.AddSection(section1Title, slide);

            // Add second slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightGreen;
            string section2Title = "Section 2";
            presentation.Sections.AddSection(section2Title, slide);

            // Add third slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightCoral;
            string section3Title = "Section 3";
            presentation.Sections.AddSection(section3Title, slide);

            // Add fourth slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightGoldenrodYellow;
            string section4Title = "Section 4";
            presentation.Sections.AddSection(section4Title, slide);

            // Add Summary Zoom frame to the first slide
            ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(50f, 50f, 300f, 200f);

            // Save presentation with Summary Zoom sections
            presentation.Save(outputPath, SaveFormat.Pptx);

            // ----- Remove a Summary Zoom Section -----
            // Get the collection of Summary Zoom sections
            ISummaryZoomSectionCollection zoomSectionCollection = summaryZoom.SummaryZoomCollection;

            // Remove the second section (index 1) from the Summary Zoom
            if (presentation.Sections.Count > 1)
            {
                zoomSectionCollection.RemoveSummaryZoomSection(presentation.Sections[1]);
            }

            // Save the presentation after removal
            presentation.Save(outputAfterRemovalPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}