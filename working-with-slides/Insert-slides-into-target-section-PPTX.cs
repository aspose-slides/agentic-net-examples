using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideInsertionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the target presentation where slides will be inserted
                var targetPresentation = new Aspose.Slides.Presentation("target.pptx");

                // Load the source presentation containing slides to insert
                var sourcePresentation = new Aspose.Slides.Presentation("source.pptx");

                // Add an empty slide to serve as the starting slide of the new section
                var layoutSlide = targetPresentation.LayoutSlides[0];
                var startSlide = targetPresentation.Slides.AddEmptySlide(layoutSlide);

                // Create a new section starting from the empty slide
                var newSection = targetPresentation.Sections.AddSection("Inserted Section", startSlide);

                // Clone each slide from the source presentation into the new section
                foreach (var sourceSlide in sourcePresentation.Slides)
                {
                    targetPresentation.Slides.AddClone(sourceSlide, newSection);
                }

                // Save the modified presentation
                targetPresentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}