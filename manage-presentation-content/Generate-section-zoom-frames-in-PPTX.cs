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
            // Define output file path
            string resultPath = Path.Combine(Directory.GetCurrentDirectory(), "SectionZoomDemo.pptx");

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a new empty slide based on the layout of the first slide
            ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Set slide background to a solid fill color
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
            slide.Background.Type = BackgroundType.OwnBackground;

            // Add a new section that contains the created slide
            ISection section = pres.Sections.AddSection("Section 1", slide);

            // Add a Section Zoom frame on the first slide linking to the created section
            ISectionZoomFrame zoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(150, 20, 100, 100, section);
            zoomFrame.ReturnToParent = true;

            // Save the presentation
            pres.Save(resultPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}