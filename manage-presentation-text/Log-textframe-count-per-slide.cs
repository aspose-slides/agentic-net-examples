// -----------------------------------------------------------------------------
// Example: Log textframe count per slide using C#
//
// Description:
// Demonstrates how to count and log the number of text frames on each slide
// of a PowerPoint presentation using Aspose.Slides for .NET. The example
// loads an input PPTX file, iterates through its slides, writes the count of
// text frames per slide to a text file, and saves the (unchanged) presentation
// to an output file. This pattern can be used for diagnostics, validation, or
// reporting in automated PPTX workflows.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, TextFrame, Slide, Count, Logging,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Generate reports of text frame usage per slide.
// - Validate slide content before publishing.
// - Automate diagnostics for PowerPoint presentations.
// - Integrate slide analysis into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace TextFrameLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path (saved after processing)
            string outputPath = "output.pptx";
            // Log file path
            string logPath = "TextFrameLog.txt";

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
                    // Prepare the log file
                    using (StreamWriter logWriter = new StreamWriter(logPath, false))
                    {
                        // Iterate through each slide
                        for (int i = 0; i < presentation.Slides.Count; i++)
                        {
                            // Get the current slide
                            Aspose.Slides.ISlide slide = presentation.Slides[i];

                            // Retrieve all text frames on the slide
                            ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);

                            // Log the count of text frames for this slide
                            logWriter.WriteLine("Slide {0}: {1} text frames", i + 1, textFrames.Length);
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Processing completed. Log written to " + logPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The presentation file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The presentation file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
