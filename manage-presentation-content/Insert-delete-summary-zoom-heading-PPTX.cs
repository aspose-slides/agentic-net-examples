using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SummaryZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Create sections with custom backgrounds
            string sectionTitle1 = "Section 1";
            string sectionTitle2 = "Section 2";
            string sectionTitle3 = "Section 3";
            string sectionTitle4 = "Section 4";

            ISlide slide = presentation.Slides[0];
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
            ISection section1 = presentation.Sections.AddSection(sectionTitle1, slide);

            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;
            ISection section2 = presentation.Sections.AddSection(sectionTitle2, slide);

            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            ISection section3 = presentation.Sections.AddSection(sectionTitle3, slide);

            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;
            ISection section4 = presentation.Sections.AddSection(sectionTitle4, slide);

            // Add a Summary Zoom frame to the first slide
            ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

            // Delete a Summary Zoom heading (remove section2 from the Summary Zoom)
            ISummaryZoomSectionCollection zoomCollection = summaryZoom.SummaryZoomCollection;
            zoomCollection.RemoveSummaryZoomSection(section2);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}