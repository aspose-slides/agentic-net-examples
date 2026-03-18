using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OverviewPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get reference to the default first slide
                    Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                    // Add additional slides
                    Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                    Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                    Aspose.Slides.ISlide slide4 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                    // Create sections with starting slides
                    Aspose.Slides.ISection introSection = presentation.Sections.AddSection("Introduction", firstSlide);
                    Aspose.Slides.ISection overviewSection = presentation.Sections.AddSection("Overview", slide2);
                    Aspose.Slides.ISection detailsSection = presentation.Sections.AddSection("Details", slide3);
                    Aspose.Slides.ISection conclusionSection = presentation.Sections.AddSection("Conclusion", slide4);

                    // Save the presentation as PPTX
                    presentation.Save("OverviewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}