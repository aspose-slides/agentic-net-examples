using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
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
                int originalSlideCount = presentation.Slides.Count;
                int originalSectionCount = presentation.Sections.Count;

                if (originalSectionCount > 0)
                {
                    // Get the last section
                    ISection lastSection = presentation.Sections[originalSectionCount - 1];
                    // Remove the last section together with its slides
                    presentation.Sections.RemoveSectionWithSlides(lastSection);
                }
                else
                {
                    Console.WriteLine("No sections found in the presentation.");
                }

                int newSlideCount = presentation.Slides.Count;
                int newSectionCount = presentation.Sections.Count;

                // Confirm reassignment of slides
                Console.WriteLine("Original slide count: " + originalSlideCount);
                Console.WriteLine("New slide count after removal: " + newSlideCount);
                Console.WriteLine("Original section count: " + originalSectionCount);
                Console.WriteLine("New section count: " + newSectionCount);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}