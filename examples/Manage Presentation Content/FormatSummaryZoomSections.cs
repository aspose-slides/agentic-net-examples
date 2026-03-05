using System;
using Aspose.Slides;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Configure first slide and add first section
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide);

        // Add second slide and section
        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide2.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide2);

        // Add third slide and section
        Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide3.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
        Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide3);

        // Add fourth slide and section
        Aspose.Slides.ISlide slide4 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide4.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide4.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide4.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;
        Aspose.Slides.ISection section4 = presentation.Sections.AddSection("Section 4", slide4);

        // Insert Summary Zoom frame on the first slide
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(50, 50, 400, 300);

        // Set titles for each Summary Zoom section
        Aspose.Slides.ISummaryZoomSectionCollection collection = summaryZoom.SummaryZoomCollection;

        Aspose.Slides.ISummaryZoomSection zoomSection1 = collection.GetSummarySection(section1);
        if (zoomSection1 != null) zoomSection1.Title = "First Section";

        Aspose.Slides.ISummaryZoomSection zoomSection2 = collection.GetSummarySection(section2);
        if (zoomSection2 != null) zoomSection2.Title = "Second Section";

        Aspose.Slides.ISummaryZoomSection zoomSection3 = collection.GetSummarySection(section3);
        if (zoomSection3 != null) zoomSection3.Title = "Third Section";

        Aspose.Slides.ISummaryZoomSection zoomSection4 = collection.GetSummarySection(section4);
        if (zoomSection4 != null) zoomSection4.Title = "Fourth Section";

        // Save the presentation
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "SummaryZoomFormatted.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}