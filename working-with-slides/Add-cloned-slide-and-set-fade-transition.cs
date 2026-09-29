// -----------------------------------------------------------------------------
// Example: Clone Slide and Apply Fade Transition using Aspose.Slides for .NET
//
// Description:
// This console application loads an existing PPTX file, clones the first slide,
// sets a fade transition on the cloned slide, and saves the modified presentation
// as a new PPTX file. It demonstrates slide duplication and transition configuration
// using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, clone slide, fade transition, slide duplication
//
// Use Cases:
// - Automating the creation of repeated slide layouts with consistent transitions.
// - Preparing presentations where certain slides need to be duplicated with effects.
// - Batch processing PowerPoint files to add transitions programmatically.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesCloneTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_cloned_fade.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file \"{0}\" does not exist.", inputPath);
                return;
            }

            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Ensure there is at least one slide to clone
                if (presentation.Slides.Count == 0)
                {
                    Console.WriteLine("Error: The presentation does not contain any slides to clone.");
                    return;
                }

                // Clone the first slide and add it to the end of the slide collection
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];
                Aspose.Slides.ISlide clonedSlide = presentation.Slides.AddClone(sourceSlide);

                // Apply a fade transition to the cloned slide
                clonedSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine("Presentation saved successfully to \"{0}\".", outputPath);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., file format not supported, I/O issues)
                Console.WriteLine("An error occurred: {0}", ex.Message);
            }
        }
    }
}
