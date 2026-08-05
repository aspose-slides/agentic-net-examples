// -----------------------------------------------------------------------------
// Example: Summarize section slide count and report using C#
//
// Description:
// Demonstrates how to summarize section slide count and report using C# and 
// Aspose.Slides for .NET. The example loads a PowerPoint presentation, reports 
// the total number of slides, the number of sections, and the slide count per 
// section, then saves the presentation. Developers can use this pattern to 
// automate PPTX workflows, validate results, or integrate presentation logic 
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Summarize, Section, Slide, 
// Count, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate summarize section slide count and report.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Total slide count
                    ISlideCollection slideCollection = presentation.Slides;
                    int totalSlides = slideCollection.Count;

                    // Sections information
                    ISectionCollection sections = presentation.Sections;
                    int sectionCount = sections.Count;

                    Console.WriteLine("Total Slides: " + totalSlides);
                    Console.WriteLine("Number of Sections: " + sectionCount);

                    for (int i = 0; i < sectionCount; i++)
                    {
                        ISection section = sections[i];
                        ISectionSlideCollection sectionSlides = section.GetSlidesListOfSection();
                        int slidesInSection = sectionSlides.Count;
                        Console.WriteLine("Section " + (i + 1) + " (" + section.Name + "): " + slidesInSection + " slide(s)");
                    }

                    // Save the presentation before exiting
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
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
