using System;
using System.IO;
using Aspose.Slides.Export;

namespace RemoveUnusedLayoutSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Source file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Example: bulk delete slides at indices 2 and 3 (zero‑based)
                    // Deleting from highest index to lowest prevents shifting issues
                    int[] indicesToDelete = new int[] { 2, 1 };
                    foreach (int slideIndex in indicesToDelete)
                    {
                        if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                        {
                            presentation.Slides[slideIndex].Remove();
                        }
                    }

                    // Remove layout slides that are no longer used
                    presentation.LayoutSlides.RemoveUnused();

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}