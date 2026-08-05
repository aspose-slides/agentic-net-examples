// -----------------------------------------------------------------------------
// Example: Set advanceaftertime to five seconds for slides in a section using C#
//
// Description:
// Demonstrates how to set the SlideShowTransition.AdvanceAfterTime property
// to five seconds (5000 milliseconds) for all slides within a specific section
// of a PowerPoint presentation using Aspose.Slides for .NET. The example loads
// an existing PPTX file, validates the target section, applies the timing to
// each slide, and saves the modified presentation.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, AdvanceAfterTime, SlideShowTransition,
// Section, Five Seconds, Presentation Automation, .NET
//
// Use Cases:
// - Apply a uniform automatic slide advance time to a section of a presentation.
// - Prepare timed slide decks for kiosks, webinars, or self‑running presentations.
// - Automate PowerPoint slide timing adjustments in batch processing tools.
// - Integrate slide timing configuration into .NET applications that generate or modify PPTX files.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Index of the target section (0‑based)
                    int targetSectionIndex = 0;

                    // Ensure the section index is valid
                    if (targetSectionIndex < 0 || targetSectionIndex >= presentation.Sections.Count)
                    {
                        Console.WriteLine("Section index out of range.");
                        return;
                    }

                    // Get the specific section
                    Aspose.Slides.ISection targetSection = presentation.Sections[targetSectionIndex];

                    // Retrieve the slides belonging to the section
                    Aspose.Slides.ISectionSlideCollection sectionSlides = targetSection.GetSlidesListOfSection();

                    // Set AdvanceAfterTime to 5 seconds (5000 ms) for each slide in the section
                    foreach (Aspose.Slides.ISlide slide in sectionSlides)
                    {
                        slide.SlideShowTransition.AdvanceAfter = true;
                        slide.SlideShowTransition.AdvanceAfterTime = 5000U; // 5 seconds
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
