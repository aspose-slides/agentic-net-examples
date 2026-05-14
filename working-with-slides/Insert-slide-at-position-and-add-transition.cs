using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

namespace InsertSlideWithTransition
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported file format
                    // Format not supported
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Determine the position where the new slide will be inserted (e.g., index 1)
            int insertIndex = 1;
            // Ensure the index is within the valid range
            if (insertIndex < 0) insertIndex = 0;
            if (insertIndex > presentation.Slides.Count) insertIndex = presentation.Slides.Count;

            // Clone the first slide and insert it at the desired position
            Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];
            Aspose.Slides.ISlide newSlide = presentation.Slides.InsertClone(insertIndex, sourceSlide);

            // Apply a custom transition effect to the newly inserted slide
            Aspose.Slides.ISlideShowTransition slideTransition = newSlide.SlideShowTransition;
            slideTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade; // Use a valid transition type
            slideTransition.Duration = 2000; // Duration in milliseconds
            slideTransition.AdvanceOnClick = true; // Advance on mouse click

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during saving (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}