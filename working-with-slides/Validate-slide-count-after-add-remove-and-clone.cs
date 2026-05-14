using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateSlideCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            Aspose.Slides.Presentation presentation;

            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load presentation: {ex.Message}");
                    return;
                }
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            using (presentation)
            {
                // Initial slide count
                int initialCount = presentation.Slides.Count;
                Console.WriteLine($"Initial slide count: {initialCount}");

                // Add an empty slide using the first layout slide
                Aspose.Slides.ILayoutSlide firstLayout = presentation.LayoutSlides[0];
                presentation.Slides.AddEmptySlide(firstLayout);
                int afterAddCount = presentation.Slides.Count;
                Console.WriteLine($"After adding a slide: {afterAddCount} (expected {initialCount + 1})");

                // Remove the first slide
                presentation.Slides[0].Remove();
                int afterRemoveCount = presentation.Slides.Count;
                Console.WriteLine($"After removing a slide: {afterRemoveCount} (expected {afterAddCount - 1})");

                // Clone the first remaining slide
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];
                presentation.Slides.AddClone(sourceSlide);
                int afterCloneCount = presentation.Slides.Count;
                Console.WriteLine($"After cloning a slide: {afterCloneCount} (expected {afterRemoveCount + 1})");

                // Save the presentation
                try
                {
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The requested format is not supported.");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error while saving: {ex.Message}");
                }
            }
        }
    }
}