using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Configure the first slide and add it to the first section
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Red;
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide);

        // Add a second slide with a green background and create the second section
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Green;
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide);

        // Add a third slide with a blue background and create the third section
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;
        Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide);

        // Add a fourth slide with a yellow background and create the fourth section
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;
        Aspose.Slides.ISection section4 = presentation.Sections.AddSection("Section 4", slide);

        // Add a Summary Zoom frame on the first slide (covers all sections)
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(50f, 50f, 300f, 200f);

        // Save the presentation in PPTX format
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SummaryZoomDemo.pptx");
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}