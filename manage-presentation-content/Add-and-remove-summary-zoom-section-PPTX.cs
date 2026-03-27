using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        string finalPath = Path.Combine(Directory.GetCurrentDirectory(), "final.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // -------------------------------------------------
        // Insert Summary Zoom with sections
        // -------------------------------------------------
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

        // Add first section
        Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide1.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightCoral;
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide1);

        // Add second section
        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide2.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGreen;
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide2);

        // Add third section
        Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide3.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightYellow;
        Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide3);

        // Add fourth section
        Aspose.Slides.ISlide slide4 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide4.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide4.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide4.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;
        Aspose.Slides.ISection section4 = presentation.Sections.AddSection("Section 4", slide4);

        // Add Summary Zoom frame
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

        // Save presentation after insertion
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();

        // -------------------------------------------------
        // Delete a Summary Zoom Section from the saved file
        // -------------------------------------------------
        Aspose.Slides.Presentation presForDeletion = new Aspose.Slides.Presentation(outputPath);

        // Assume the Summary Zoom frame is the first shape on the first slide
        Aspose.Slides.ISummaryZoomFrame zoomFrame = presForDeletion.Slides[0].Shapes[0] as Aspose.Slides.ISummaryZoomFrame;
        if (zoomFrame != null)
        {
            Aspose.Slides.ISummaryZoomSectionCollection collection = zoomFrame.SummaryZoomCollection;
            // Remove the first section from the Summary Zoom
            if (presForDeletion.Sections.Count > 0)
            {
                collection.RemoveSummaryZoomSection(presForDeletion.Sections[0]);
            }
        }

        // Save presentation after deletion
        presForDeletion.Save(finalPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presForDeletion.Dispose();

        Console.WriteLine("Operations completed successfully.");
    }
}