using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get reference to the default first slide
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                // Add additional slides to demonstrate sections (numbered list)
                Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                Aspose.Slides.ISlide slide4 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                // Create sections to represent numbered list items
                // Section 1 starts with slide2
                Aspose.Slides.ISection section1 = presentation.Sections.AddSection("1. Introduction", slide2);
                // Section 2 starts with slide3
                Aspose.Slides.ISection section2 = presentation.Sections.AddSection("2. Details", slide3);
                // Section 3 starts with slide4
                Aspose.Slides.ISection section3 = presentation.Sections.AddSection("3. Conclusion", slide4);

                // Benefits of using numbered sections (explained in comments):
                // - Improves navigation: sections appear in the slide sorter and outline view.
                // - Enables quick reordering of grouped slides.
                // - Allows exporting or printing specific sections.
                // - Provides a logical hierarchy for audience comprehension.

                // Save the presentation before exiting
                presentation.Save("NumberedListSections.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}