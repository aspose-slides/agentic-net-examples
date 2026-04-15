using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DisableSectionTransitions
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Ensure there is at least one section
                    if (presentation.Sections.Count > 0)
                    {
                        // Target the first section (change index as needed)
                        Aspose.Slides.ISection targetSection = presentation.Sections[0];

                        // Get all slides belonging to the section
                        Aspose.Slides.ISectionSlideCollection slidesInSection = targetSection.GetSlidesListOfSection();

                        // Disable transitions for each slide in the section
                        for (int i = 0; i < slidesInSection.Count; i++)
                        {
                            Aspose.Slides.ISlide slide = slidesInSection[i];
                            slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.None;
                            slide.SlideShowTransition.AdvanceOnClick = false;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}