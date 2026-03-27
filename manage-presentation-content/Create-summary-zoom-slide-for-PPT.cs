using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // First slide and section
        ISlide slide = presentation.Slides[0];
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Red;
        ISection section1 = presentation.Sections.AddSection("Section 1", slide);

        // Second slide and section
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Green;
        ISection section2 = presentation.Sections.AddSection("Section 2", slide);

        // Third slide and section
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;
        ISection section3 = presentation.Sections.AddSection("Section 3", slide);

        // Fourth slide and section
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;
        ISection section4 = presentation.Sections.AddSection("Section 4", slide);

        // Add Summary Zoom frame on the first slide
        ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150, 20, 500, 250);

        // Save the presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SummaryZoom.pptx");
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}