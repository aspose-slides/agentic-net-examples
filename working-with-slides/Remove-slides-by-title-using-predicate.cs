using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveSlidesByTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Predicate function to match slide titles containing a keyword
                Func<ISlide, bool> titleMatches = slide =>
                {
                    // Use the slide's Name property as a placeholder for the title
                    // Adjust this logic if a different property holds the title
                    return slide.Name != null && slide.Name.Contains("Keyword");
                };

                // Collect indices of slides to remove
                List<int> indicesToRemove = new List<int>();
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    if (titleMatches(slide))
                    {
                        indicesToRemove.Add(i);
                    }
                }

                // Remove slides in reverse order to maintain correct indexing
                for (int i = indicesToRemove.Count - 1; i >= 0; i--)
                {
                    pres.Slides.RemoveAt(indicesToRemove[i]);
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}