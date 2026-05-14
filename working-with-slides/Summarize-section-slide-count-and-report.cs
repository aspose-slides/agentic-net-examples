using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SummarizeSections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Total slide count
                    Aspose.Slides.ISlideCollection slideCollection = presentation.Slides;
                    int totalSlides = slideCollection.Count;

                    // Sections information
                    Aspose.Slides.ISectionCollection sections = presentation.Sections;
                    int sectionCount = sections.Count;

                    Console.WriteLine("Total Slides: " + totalSlides);
                    Console.WriteLine("Number of Sections: " + sectionCount);

                    for (int i = 0; i < sectionCount; i++)
                    {
                        Aspose.Slides.ISection section = sections[i];
                        Aspose.Slides.ISectionSlideCollection sectionSlides = section.GetSlidesListOfSection();
                        int slidesInSection = sectionSlides.Count;
                        Console.WriteLine("Section " + (i + 1) + " (" + section.Name + "): " + slidesInSection + " slide(s)");
                    }

                    // Save the presentation before exiting
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O, corrupted file)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}