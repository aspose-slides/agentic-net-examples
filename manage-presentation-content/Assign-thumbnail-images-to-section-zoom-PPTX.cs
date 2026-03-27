using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SectionZoomDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string dataDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(dataDir, "template.pptx");
            string outputPath = Path.Combine(dataDir, "SectionZoomDemo.pptx");

            // Load existing presentation if it exists, otherwise create a new one
            Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }

            // Create first slide and section
            ISlide slide1 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide1.Background.Type = BackgroundType.OwnBackground;
            slide1.Background.FillFormat.FillType = FillType.Solid;
            slide1.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;
            ISection section1 = pres.Sections.AddSection("Section 1", slide1);

            // Create second slide and section
            ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            slide2.Background.Type = BackgroundType.OwnBackground;
            slide2.Background.FillFormat.FillType = FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = Color.LightCoral;
            ISection section2 = pres.Sections.AddSection("Section 2", slide2);

            // Add custom thumbnail image for Section 1
            string thumbPath1 = Path.Combine(dataDir, "thumb1.png");
            if (File.Exists(thumbPath1))
            {
                IPPImage thumbImage1 = pres.Images.AddImage(Images.FromFile(thumbPath1));
                ISectionZoomFrame zoom1 = pres.Slides[0].Shapes.AddSectionZoomFrame(50, 50, 100, 100, section1, thumbImage1);
            }

            // Add custom thumbnail image for Section 2
            string thumbPath2 = Path.Combine(dataDir, "thumb2.png");
            if (File.Exists(thumbPath2))
            {
                IPPImage thumbImage2 = pres.Images.AddImage(Images.FromFile(thumbPath2));
                ISectionZoomFrame zoom2 = pres.Slides[0].Shapes.AddSectionZoomFrame(200, 50, 100, 100, section2, thumbImage2);
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}