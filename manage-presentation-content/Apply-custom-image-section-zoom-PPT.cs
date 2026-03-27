using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output and image paths
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SectionZoomDemo.pptx");
        string imagePath1 = Path.Combine(Directory.GetCurrentDirectory(), "image1.png");
        string imagePath2 = Path.Combine(Directory.GetCurrentDirectory(), "image2.png");

        // Verify that image files exist
        if (!File.Exists(imagePath1) || !File.Exists(imagePath2))
        {
            Console.WriteLine("Required image files not found.");
            return;
        }

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add first section with a slide
        ISlide slide1 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        ISection section1 = pres.Sections.AddSection("First Section", slide1);

        // Add second section with a slide
        ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        ISection section2 = pres.Sections.AddSection("Second Section", slide2);

        // Add custom images to the presentation
        IPPImage img1 = pres.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath1));
        IPPImage img2 = pres.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath2));

        // Add Section Zoom frames with custom images on the first slide
        ISectionZoomFrame zoom1 = pres.Slides[0].Shapes.AddSectionZoomFrame(50, 50, 100, 100, section1, img1);
        ISectionZoomFrame zoom2 = pres.Slides[0].Shapes.AddSectionZoomFrame(200, 50, 100, 100, section2, img2);

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}