using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the default slide
                Aspose.Slides.ISlide defaultSlide = presentation.Slides[0];

                // Add additional empty slides
                Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                // Create sections using the appropriate AddSection method
                Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Introduction", slide1);
                Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Details", slide3);

                // Save the presentation
                presentation.Save("SectionsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}