using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHiddenSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_cleaned.pptx";

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
                    // Remove hidden slides by iterating backwards
                    for (int i = presentation.Slides.Count - 1; i >= 0; i--)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Hidden slides are identified by the Hidden property
                        if (slide.Hidden)
                        {
                            slide.Remove();
                        }
                    }

                    // Save the cleaned presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved without hidden slides: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}