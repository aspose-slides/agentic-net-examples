using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add first slide and create Section 1
            Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide1.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;
            Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide1);

            // Add second slide and create Section 2
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = Color.LightGreen;
            Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide2);

            // Add a Summary Zoom frame on the first slide
            Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150, 20, 500, 250);

            // Get the collection of Summary Zoom sections
            Aspose.Slides.ISummaryZoomSectionCollection zoomCollection = summaryZoom.SummaryZoomCollection;

            // Add a Summary Zoom Section for Section 2
            Aspose.Slides.ISummaryZoomSection addedSection = zoomCollection.AddSummaryZoomSection(section2);
            addedSection.Title = "Added Section";

            // Remove the Summary Zoom Section for Section 2
            zoomCollection.RemoveSummaryZoomSection(section2);

            // Save the presentation
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AddRemoveSummaryZoomSection.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}