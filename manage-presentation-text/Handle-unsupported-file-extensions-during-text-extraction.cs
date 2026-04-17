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
            // Determine the input file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "sample.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File does not exist - " + inputPath);
                return;
            }

            try
            {
                // Extract raw text from the presentation using a valid arranging mode
                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    TextExtractionArrangingMode.Unarranged);

                // Output extracted text for each slide
                ISlideText[] slides = presentationText.SlidesText;
                for (int i = 0; i < slides.Length; i++)
                {
                    Console.WriteLine("Slide " + (i + 1) + " Text:");
                    Console.WriteLine(slides[i].Text);
                    Console.WriteLine("---------------------------");
                }

                // Load the presentation and save it (required before exit)
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save the presentation back to the same file (or change the path as needed)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Warning: Unsupported PPT format - " + ex.Message);
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Warning: Unsupported PPTX format - " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}