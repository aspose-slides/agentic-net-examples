using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set slide and notes view zoom to 120%
        presentation.ViewProperties.SlideViewProperties.Scale = 120;
        presentation.ViewProperties.NotesViewProperties.Scale = 120;

        // Ensure there are at least two slides for the zoom frame
        if (presentation.Slides.Count < 2)
        {
            Aspose.Slides.ISlide extraSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        }

        // Add a Zoom Frame linking to the second slide
        Aspose.Slides.ISlide targetSlide = presentation.Slides[1];
        Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150f, 20f, 100f, 100f, targetSlide);
        zoomFrame.ReturnToParent = true;

        // Create a new section with its own slide and add a Section Zoom Frame
        Aspose.Slides.ISlide sectionSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.ISection section = presentation.Sections.AddSection("New Section", sectionSlide);
        Aspose.Slides.ISectionZoomFrame sectionZoom = presentation.Slides[0].Shapes.AddSectionZoomFrame(300f, 20f, 100f, 100f, section);
        sectionZoom.ReturnToParent = true;

        // Ensure there are at least four slides for the summary zoom
        while (presentation.Slides.Count < 4)
        {
            Aspose.Slides.ISlide extraSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        }

        // Set distinct background colors for the first four slides
        Aspose.Slides.ISlide slide0 = presentation.Slides[0];
        slide0.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide0.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide0.Background.FillFormat.SolidFillColor.Color = Color.Red;

        Aspose.Slides.ISlide slide1 = presentation.Slides[1];
        slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide1.Background.FillFormat.SolidFillColor.Color = Color.Green;

        Aspose.Slides.ISlide slide2 = presentation.Slides[2];
        slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide2.Background.FillFormat.SolidFillColor.Color = Color.Blue;

        Aspose.Slides.ISlide slide3 = presentation.Slides[3];
        slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide3.Background.FillFormat.SolidFillColor.Color = Color.Yellow;

        // Add sections corresponding to each slide
        presentation.Sections.AddSection("Section 1", slide0);
        presentation.Sections.AddSection("Section 2", slide1);
        presentation.Sections.AddSection("Section 3", slide2);
        presentation.Sections.AddSection("Section 4", slide3);

        // Add a Summary Zoom Frame on the first slide
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(450f, 20f, 300f, 200f);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}