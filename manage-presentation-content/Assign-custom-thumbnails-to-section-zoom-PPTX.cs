using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SectionZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add two empty slides to the presentation
                Aspose.Slides.ISlide slide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

                // Create two sections and assign the slides to them
                Aspose.Slides.ISection section1 = pres.Sections.AddSection("Section 1", slide1);
                Aspose.Slides.ISection section2 = pres.Sections.AddSection("Section 2", slide2);

                // Load custom thumbnail images from files (replace with your image paths)
                byte[] imageData1 = File.ReadAllBytes("thumb1.png");
                byte[] imageData2 = File.ReadAllBytes("thumb2.png");

                Aspose.Slides.IPPImage thumbImage1 = pres.Images.AddImage(imageData1);
                Aspose.Slides.IPPImage thumbImage2 = pres.Images.AddImage(imageData2);

                // Add Section Zoom frames to the first slide and assign custom thumbnails
                Aspose.Slides.ISectionZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddSectionZoomFrame(50f, 50f, 100f, 100f, section1);
                zoomFrame1.ZoomImage = thumbImage1;
                zoomFrame1.ImageType = Aspose.Slides.ZoomImageType.Cover;

                Aspose.Slides.ISectionZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddSectionZoomFrame(200f, 50f, 100f, 100f, section2);
                zoomFrame2.ZoomImage = thumbImage2;
                zoomFrame2.ImageType = Aspose.Slides.ZoomImageType.Cover;

                // Save the presentation
                pres.Save("SectionZoomWithCustomThumbnails.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}