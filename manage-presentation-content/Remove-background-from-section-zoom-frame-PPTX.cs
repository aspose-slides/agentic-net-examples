using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Output file path
        string outputFileName = "SectionZoomBackgroundStripped.pptx";
        string resultPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a slide for the first section and set its background
        ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;

        // Add a section that contains the slide
        ISection section = pres.Sections.AddSection("First Section", slide);

        // Add a Section Zoom frame on the first slide
        ISectionZoomFrame zoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(150, 20, 50, 50, section);

        // Strip the background from the zoom object's image
        zoomFrame.ShowBackground = false;

        // Save the presentation
        pres.Save(resultPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}