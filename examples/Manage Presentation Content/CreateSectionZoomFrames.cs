using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationContent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file names
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            string resultPath = Path.Combine(dataDir, "SectionZoomWithImage.pptx");
            string imagePath = Path.Combine(dataDir, "customImage.png"); // Ensure this image exists

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a first slide (used as the slide that will contain the Section Zoom frame)
            Aspose.Slides.ISlide firstSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Add a second slide that will belong to the new section
            Aspose.Slides.ISlide sectionSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Create a new section and associate it with the second slide
            Aspose.Slides.ISection section = pres.Sections.AddSection("My Section", sectionSlide);

            // Load an external image and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage imgX = pres.Images.AddImage(img);

            // Add a Section Zoom frame to the first slide, using the custom image
            Aspose.Slides.ISectionZoomFrame zoomFrame = firstSlide.Shapes.AddSectionZoomFrame(150f, 20f, 100f, 100f, section, imgX);

            // Optionally set navigation behavior
            zoomFrame.ReturnToParent = false;

            // Save the presentation
            pres.Save(resultPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}