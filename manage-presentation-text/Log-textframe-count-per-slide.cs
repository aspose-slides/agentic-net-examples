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