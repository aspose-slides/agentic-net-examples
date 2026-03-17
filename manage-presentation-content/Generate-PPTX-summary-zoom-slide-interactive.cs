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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Section 1
                Aspose.Slides.ISlide slide1 = presentation.Slides[0];
                slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide1.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                presentation.Sections.AddSection("Section 1", slide1);

                // Section 2
                Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide2.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;
                presentation.Sections.AddSection("Section 2", slide2);

                // Section 3
                Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide3.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                presentation.Sections.AddSection("Section 3", slide3);

                // Section 4
                Aspose.Slides.ISlide slide4 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                slide4.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide4.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide4.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;
                presentation.Sections.AddSection("Section 4", slide4);

                // Add Summary Zoom frame to the first slide
                Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

                // Save the presentation
                string outputPath = "SummaryZoomPresentation.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}