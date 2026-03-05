using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationContent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add two empty slides based on the layout of the first slide
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Set custom backgrounds for the new slides
            slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

            slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

            // Add a Zoom Frame linking to slide2
            Aspose.Slides.IZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddZoomFrame(50f, 50f, 100f, 100f, slide2);
            zoomFrame1.ShowBackground = true;

            // Load a custom image to be used in the second Zoom Frame
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "logo.png");
            Aspose.Slides.IPPImage customImage = presentation.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath));

            // Add a Zoom Frame linking to slide3 with the custom image
            Aspose.Slides.IZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddZoomFrame(200f, 50f, 100f, 100f, slide3, customImage);
            zoomFrame2.LineFormat.Width = 5f;
            zoomFrame2.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
            zoomFrame2.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

            // Save the presentation in PPT format
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ZoomFramesPresentation.ppt");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}