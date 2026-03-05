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

        // Add a slide that will contain the Section Zoom frame
        Aspose.Slides.ISlide zoomSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Set a solid background for the zoom slide
        zoomSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        zoomSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        zoomSlide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;

        // Add first content slide and create the first section
        Aspose.Slides.ISlide contentSlide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", contentSlide1);

        // Add second content slide and create the second section
        Aspose.Slides.ISlide contentSlide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", contentSlide2);

        // Add a Section Zoom frame on the zoom slide linking to the first section
        Aspose.Slides.ISectionZoomFrame sectionZoom = zoomSlide.Shapes.AddSectionZoomFrame(100f, 100f, 200f, 100f, section1);

        // Change the target of the zoom frame to the second section
        sectionZoom.TargetSection = section2;

        // Save the presentation in PPT format
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SectionZoomDemo.ppt");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
    }
}