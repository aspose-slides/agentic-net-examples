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
        string resultPath = Path.Combine(Directory.GetCurrentDirectory(), "SectionZoomDemo.pptx");

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add first slide and set background
        ISlide slide1 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        slide1.Background.FillFormat.FillType = FillType.Solid;
        slide1.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
        slide1.Background.Type = BackgroundType.OwnBackground;

        // Add second slide and set background
        ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        slide2.Background.FillFormat.FillType = FillType.Solid;
        slide2.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;
        slide2.Background.Type = BackgroundType.OwnBackground;

        // Create a section containing the second slide
        ISection section = pres.Sections.AddSection("My Section", slide2);

        // Add a Section Zoom frame on the first slide linking to the created section
        ISectionZoomFrame zoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(100f, 100f, 200f, 100f, section);

        // Save the presentation
        pres.Save(resultPath, SaveFormat.Pptx);
    }
}