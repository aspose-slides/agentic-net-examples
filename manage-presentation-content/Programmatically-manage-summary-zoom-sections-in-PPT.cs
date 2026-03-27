using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string dataDir = Directory.GetCurrentDirectory();
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Load existing presentation if it exists, otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Create four sections with distinct background colors
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Red;
        string section1 = "Section 1";
        presentation.Sections.AddSection(section1, slide);

        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Green;
        string section2 = "Section 2";
        presentation.Sections.AddSection(section2, slide);

        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;
        string section3 = "Section 3";
        presentation.Sections.AddSection(section3, slide);

        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;
        string section4 = "Section 4";
        presentation.Sections.AddSection(section4, slide);

        // Add a Summary Zoom frame on the first slide
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

        // Add Summary Zoom sections for each created section
        Aspose.Slides.ISummaryZoomSectionCollection collection = summaryZoom.SummaryZoomCollection;
        collection.AddSummaryZoomSection(presentation.Sections[0]);
        collection.AddSummaryZoomSection(presentation.Sections[1]);
        collection.AddSummaryZoomSection(presentation.Sections[2]);
        collection.AddSummaryZoomSection(presentation.Sections[3]);

        // Update titles and descriptions of the summary zoom sections
        Aspose.Slides.ISummaryZoomSection zoomSection0 = collection[0];
        zoomSection0.Title = "Intro";
        zoomSection0.Description = "First part";

        Aspose.Slides.ISummaryZoomSection zoomSection1 = collection[1];
        zoomSection1.Title = "Middle";
        zoomSection1.Description = "Second part";

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}