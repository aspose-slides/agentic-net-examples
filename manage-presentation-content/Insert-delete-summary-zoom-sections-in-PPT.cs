using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Ensure at least one section exists
        if (presentation.Sections.Count == 0)
        {
            Aspose.Slides.ISection defaultSection = presentation.Sections.AddSection("Section 1", presentation.Slides[0]);
        }

        // Configure first slide background
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Add sections with colored slides
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide);

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

        Aspose.Slides.ISlide slide4 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide4.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide4.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide4.Background.FillFormat.SolidFillColor.Color = Color.LightGoldenrodYellow;
        Aspose.Slides.ISection section4 = presentation.Sections.AddSection("Section 4", slide4);

        // Add a Summary Zoom frame
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150, 20, 500, 250);

        // Add a Summary Zoom section for Section 2
        Aspose.Slides.ISummaryZoomSection addedSection = summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section2);

        // Add and then remove a Summary Zoom section for Section 3
        Aspose.Slides.ISummaryZoomSection addedSection3 = summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section3);
        summaryZoom.SummaryZoomCollection.RemoveSummaryZoomSection(section3);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}