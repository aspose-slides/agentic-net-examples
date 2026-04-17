using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractTextFromStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation file
            string inputPath = "sample.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Open the file as a read‑only stream
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    // Extract raw text from the presentation using PresentationFactory
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        fileStream,
                        TextExtractionArrangingMode.Unarranged);

                    // Output the extracted text slide by slide
                    foreach (ISlideText slideText in presentationText.SlidesText)
                    {
                        Console.WriteLine(slideText.Text);
                    }

                    // Reset stream position to read the presentation again
                    fileStream.Position = 0;

                    // Load the presentation for saving (no modifications in this example)
                    using (IPresentation presentation = PresentationFactory.Instance.ReadPresentation(fileStream))
                    {
                        // Save the presentation to a new file before exiting
                        string outputPath = "output.pptx";
                        presentation.Save(outputPath, SaveFormat.Pptx);
                        Console.WriteLine("Presentation saved to: " + outputPath);
                    }
                }
                // Handle unsupported PPTX format
                catch (PptxUnsupportedFormatException)
                {
                    Console.WriteLine("The file format is not supported (PPTX).");
                }
                // Handle unsupported PPT format
                catch (PptUnsupportedFormatException)
                {
                    Console.WriteLine("The file format is not supported (PPT).");
                }
                // General exception handling (e.g., I/O errors, corrupted files)
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}