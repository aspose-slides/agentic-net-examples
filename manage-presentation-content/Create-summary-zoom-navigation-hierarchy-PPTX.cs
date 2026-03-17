using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SummaryZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // First slide
                    Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                    firstSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    firstSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    firstSlide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

                    // Add additional slides and sections
                    Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    slide2.Background.FillFormat.SolidFillColor.Color = Color.LightGreen;
                    Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide2);

                    Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    slide3.Background.FillFormat.SolidFillColor.Color = Color.LightCoral;
                    Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide3);

                    // Add a Summary Zoom frame to the first slide
                    Aspose.Slides.ISummaryZoomFrame summaryZoom = firstSlide.Shapes.AddSummaryZoomFrame(150, 20, 500, 250);

                    // Optionally, add specific sections to the Summary Zoom (already includes all sections by default)
                    summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(presentation.Sections[0]);
                    summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section2);
                    summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section3);

                    // Save the presentation
                    string outputPath = "SummaryZoomPresentation.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}