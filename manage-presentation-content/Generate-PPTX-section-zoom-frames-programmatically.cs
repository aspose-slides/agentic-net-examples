using System;
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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add first slide and configure its background
            Aspose.Slides.ISlide slide1 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide1.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.YellowGreen;
            slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

            // Create first section starting with slide1
            Aspose.Slides.ISection section1 = pres.Sections.AddSection("Section 1", slide1);

            // Add second slide and configure its background
            Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;
            slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

            // Create second section starting with slide2
            Aspose.Slides.ISection section2 = pres.Sections.AddSection("Section 2", slide2);

            // Add a Section Zoom frame on the first slide linking to the second section
            Aspose.Slides.ISectionZoomFrame zoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(150, 20, 100, 100, section2);

            // Save the presentation
            string resultPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "SectionZoomDemo.pptx");
            pres.Save(resultPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}