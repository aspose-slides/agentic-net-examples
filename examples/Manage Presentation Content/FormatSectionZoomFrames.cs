using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Configure the background of the first slide
        Aspose.Slides.ISlide slide0 = presentation.Slides[0];
        slide0.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide0.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide0.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

        // Add a second slide and create Section 1
        Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide1.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGreen;
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide1);

        // Add a third slide and create Section 2
        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide2.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightCoral;
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide2);

        // Add a Section Zoom frame on the first slide referencing Section 2
        Aspose.Slides.ISectionZoomFrame sectionZoom = presentation.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 100f, 100f, section2);
        // Change the target section of the zoom frame to Section 1
        sectionZoom.TargetSection = section1;

        // Save the presentation in PPT format
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "SectionZoomDemo.ppt");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
    }
}