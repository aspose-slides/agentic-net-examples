using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DuplicateLayoutConsolidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_consolidated.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Get all layout slides in the presentation
                IGlobalLayoutSlideCollection layoutSlides = presentation.LayoutSlides;

                // Detect and remove duplicate layout slides
                for (int i = 0; i < layoutSlides.Count; i++)
                {
                    for (int j = i + 1; j < layoutSlides.Count; )
                    {
                        // Compare layout slides for structural equality
                        if (layoutSlides[i].Equals(layoutSlides[j]))
                        {
                            // Remove duplicate only if it is not used by any slide
                            // HasDependingSlides indicates whether the layout is referenced
                            // (Assuming the property exists; otherwise, skip removal)
                            var duplicateLayout = layoutSlides[j];
                            var hasDependingSlidesProperty = duplicateLayout.GetType().GetProperty("HasDependingSlides");
                            bool hasDependingSlides = hasDependingSlidesProperty != null && (bool)hasDependingSlidesProperty.GetValue(duplicateLayout);

                            if (!hasDependingSlides)
                            {
                                layoutSlides.Remove(duplicateLayout);
                                // Do not increment j because collection size decreased
                                continue;
                            }
                        }
                        j++;
                    }
                }

                // Remove any remaining unused layout slides
                layoutSlides.RemoveUnused();

                // Save the consolidated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add specific handling for unsupported file formats if needed
            }
        }
    }
}