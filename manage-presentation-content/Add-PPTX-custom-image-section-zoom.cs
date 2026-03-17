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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a slide based on the first layout slide
            Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Set slide background to solid YellowGreen
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.YellowGreen;
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

            // Add a section that starts from the created slide
            Aspose.Slides.ISection section = pres.Sections.AddSection("Custom Section", slide);

            // Load custom image for the section zoom frame
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "zoomImage.png");
            byte[] imageData = File.ReadAllBytes(imagePath);
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

            // Add a Section Zoom Frame with the custom image on the first slide
            Aspose.Slides.ISectionZoomFrame zoom = pres.Slides[0].Shapes.AddSectionZoomFrame(150f, 20f, 100f, 100f, section, img);

            // Save the presentation
            string resultPath = Path.Combine(Directory.GetCurrentDirectory(), "SectionZoomWithImage.pptx");
            pres.Save(resultPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}