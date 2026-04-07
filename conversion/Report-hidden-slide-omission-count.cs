using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReportHiddenSlideOmission
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation file
            string inputPath = "input.pptx";
            // Path to the output presentation file
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
                    // Retrieve the number of hidden slides
                    int hiddenSlides = presentation.DocumentProperties.HiddenSlides;

                    // When ShowHiddenSlides is false (default), all hidden slides are omitted
                    Console.WriteLine("Total hidden slides omitted (ShowHiddenSlides = false): " + hiddenSlides);

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("File format not supported: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("File format not supported: " + ex.Message);
            }
            // Handle other not supported operations
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Operation not supported: " + ex.Message);
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}