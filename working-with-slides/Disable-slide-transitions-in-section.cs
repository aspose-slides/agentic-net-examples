using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DisableSlideTransitions
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there is at least one section
                    if (presentation.Sections.Count > 0)
                    {
                        // Get the first section (change index as needed)
                        ISection targetSection = presentation.Sections[0];

                        // Retrieve all slides belonging to the section
                        ISectionSlideCollection sectionSlides = targetSection.GetSlidesListOfSection();

                        // Disable transitions for each slide in the section
                        foreach (ISlide slide in sectionSlides)
                        {
                            slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.None;
                            slide.SlideShowTransition.AdvanceOnClick = true;
                            slide.SlideShowTransition.AdvanceAfter = false;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}