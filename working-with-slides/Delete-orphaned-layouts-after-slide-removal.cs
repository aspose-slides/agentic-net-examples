using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteOrphanedLayouts
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";
            string outputFile = "output.pptx";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputFile))
                {
                    // Find a specific layout (e.g., Title) to remove its dependent slides
                    ILayoutSlide targetLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Title);
                    if (targetLayout != null)
                    {
                        // Remove slides that use the target layout (iterate backwards)
                        for (int i = presentation.Slides.Count - 1; i >= 0; i--)
                        {
                            ISlide slide = presentation.Slides[i];
                            if (slide.LayoutSlide == targetLayout)
                            {
                                presentation.Slides.RemoveAt(i);
                            }
                        }
                    }

                    // Remove any layout slides that are no longer used
                    presentation.LayoutSlides.RemoveUnused();

                    // Save the modified presentation
                    presentation.Save(outputFile, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}