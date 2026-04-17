using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path, section name, and output path can be passed as arguments.
            string inputPath = "input.pptx";
            string sectionName = "Section 1";
            string outputPath = "output.pptx";

            if (args.Length > 0) inputPath = args[0];
            if (args.Length > 1) sectionName = args[1];
            if (args.Length > 2) outputPath = args[2];

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation.
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Locate the requested section by name.
                Aspose.Slides.ISection targetSection = null;
                for (int i = 0; i < presentation.Sections.Count; i++)
                {
                    if (presentation.Sections[i].Name == sectionName)
                    {
                        targetSection = presentation.Sections[i];
                        break;
                    }
                }

                if (targetSection != null)
                {
                    // Get all slides belonging to the section.
                    Aspose.Slides.ISectionSlideCollection slidesInSection = targetSection.GetSlidesListOfSection();

                    // Set AdvanceAfterTime to 5 seconds (5000 ms) for each slide.
                    for (int i = 0; i < slidesInSection.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = slidesInSection[i];
                        Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;
                        transition.AdvanceAfter = true;
                        transition.AdvanceAfterTime = 5000;
                    }
                }
                else
                {
                    Console.WriteLine("Section not found: " + sectionName);
                }

                // Save the modified presentation.
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            // Handle unsupported format exception.
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported.");
            }
            // General exception handling.
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}