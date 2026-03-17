using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure first slide and add first section
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;
            Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide);

            // Add second slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGreen;
            Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide);

            // Add third slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightCoral;
            Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide);

            // Insert Summary Zoom frame on the first slide
            Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150, 20, 500, 250);

            // Add a Summary Zoom Section for the second section
            Aspose.Slides.ISummaryZoomSection addedSection = summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section2);
            addedSection.Title = "Section 2";
            addedSection.Description = "Link to Section 2";

            // Remove the previously added Summary Zoom Section
            summaryZoom.SummaryZoomCollection.RemoveSummaryZoomSection(section2);

            // Save the presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SummaryZoomDemo.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}