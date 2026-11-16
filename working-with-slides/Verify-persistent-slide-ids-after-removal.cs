// -----------------------------------------------------------------------------
// Example: Verify Persistent Slide IDs After Removing a Slide
//
// Description:
// This console program demonstrates how to verify that slide persistent IDs
// remain unchanged after removing a neighboring slide using C# and
// Aspose.Slides for .NET. It creates a sample PPTX if none exists, records the
// IDs of the first and third slides, removes the second slide, retrieves the
// original slides by their stored IDs, and confirms that the IDs are still the
// same. The modified presentation is then saved.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide persistent ID, slide removal verification
//
// Use Cases:
// - Automated slide manipulation integrity check
// - Batch processing of presentations while preserving slide identity
// - Validation of slide IDs in custom slide management tools
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            // Ensure input file exists; create a sample presentation if missing
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                // The default presentation contains one slide; add two more empty slides
                samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Verify there are at least three slides
            if (presentation.Slides.Count < 3)
            {
                Console.Error.WriteLine("The presentation must contain at least three slides.");
                presentation.Dispose();
                return 1;
            }

            // Record persistent IDs of the first and third slides
            uint firstSlideId = presentation.Slides[0].SlideId;
            uint thirdSlideId = presentation.Slides[2].SlideId;

            // Remove the second slide (index 1)
            presentation.Slides.RemoveAt(1);

            // Retrieve slides by stored IDs
            Aspose.Slides.ISlide firstSlide = null;
            Aspose.Slides.ISlide thirdSlide = null;
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                if (slide.SlideId == firstSlideId)
                {
                    firstSlide = slide;
                }
                if (slide.SlideId == thirdSlideId)
                {
                    thirdSlide = slide;
                }
            }

            // Validate that the IDs are unchanged and slides are found
            bool success = true;
            if (firstSlide == null)
            {
                Console.Error.WriteLine("First slide could not be located after removal.");
                success = false;
            }
            else if (firstSlide.SlideId != firstSlideId)
            {
                Console.Error.WriteLine("First slide ID mismatch after removal.");
                success = false;
            }

            if (thirdSlide == null)
            {
                Console.Error.WriteLine("Third slide could not be located after removal.");
                success = false;
            }
            else if (thirdSlide.SlideId != thirdSlideId)
            {
                Console.Error.WriteLine("Third slide ID mismatch after removal.");
                success = false;
            }

            if (!success)
            {
                presentation.Dispose();
                return 1;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Slide IDs verified successfully. Modified presentation saved to " + outputPath);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
            return 1;
        }
    }
}
