using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveSlidesByTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
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
                    // Define the predicate for removal (e.g., titles containing "Confidential")
                    Predicate<ISlide> shouldRemove = delegate (ISlide slide)
                    {
                        // Use the slide's Name property as the title identifier
                        return !string.IsNullOrEmpty(slide.Name) && slide.Name.IndexOf("Confidential", StringComparison.OrdinalIgnoreCase) >= 0;
                    };

                    // Collect slides that match the predicate
                    List<ISlide> slidesToRemove = new List<ISlide>();
                    foreach (ISlide slide in presentation.Slides)
                    {
                        if (shouldRemove(slide))
                        {
                            slidesToRemove.Add(slide);
                        }
                    }

                    // Remove the collected slides from the presentation
                    foreach (ISlide slide in slidesToRemove)
                    {
                        presentation.Slides.Remove(slide);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}