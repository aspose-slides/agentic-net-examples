using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file name and path
        string resultFileName = "SectionZoomDemo.pptx";
        string resultPath = Path.Combine(Directory.GetCurrentDirectory(), resultFileName);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add an empty slide based on the layout of the first slide
        Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        // Set slide background to solid YellowGreen
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

        // Add a new section starting at the created slide
        Aspose.Slides.ISection section = pres.Sections.AddSection("First Section", slide);

        // Add a Section Zoom frame on the first slide referencing the created section
        Aspose.Slides.ISectionZoomFrame zoom = pres.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 100f, 100f, section);

        // Save the presentation
        pres.Save(resultPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}