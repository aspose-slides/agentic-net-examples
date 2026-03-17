using System;
using System.IO;
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add two empty slides based on the layout of the first slide
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Set background for slide2
            slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

            // Set background for slide3
            slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

            // Add first zoom frame on the first slide referencing slide2
            Aspose.Slides.IZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddZoomFrame(150f, 20f, 50f, 50f, slide2);
            zoomFrame1.ShowBackground = false;

            // Prepare image for second zoom frame
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "logo.png");
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath));

            // Add second zoom frame on the first slide referencing slide3 with image
            Aspose.Slides.IZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddZoomFrame(250f, 20f, 50f, 50f, slide3, image);
            zoomFrame2.LineFormat.Width = 2f;
            zoomFrame2.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
            zoomFrame2.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

            // Set zoom scaling for slide view and notes view
            presentation.ViewProperties.SlideViewProperties.Scale = 100;
            presentation.ViewProperties.NotesViewProperties.Scale = 100;

            // Save the presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ZoomFormattedPresentation.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}