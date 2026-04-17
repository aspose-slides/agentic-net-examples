using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractTextAndCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string filePath = "sample.pptx";

            // Verify that the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Presentation file not found: " + filePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(filePath))
                {
                    // Expected slide count from document properties (excludes hidden/master slides)
                    int expectedSlideCount = presentation.DocumentProperties.Slides;

                    // Extract raw text from slides (excluding master slides)
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        filePath,
                        TextExtractionArrangingMode.Unarranged);

                    // Count of extracted slide texts
                    int extractedSlideCount = presentationText.SlidesText.Length;

                    Console.WriteLine("Expected slide count: " + expectedSlideCount);
                    Console.WriteLine("Extracted slide text count: " + extractedSlideCount);

                    if (expectedSlideCount == extractedSlideCount)
                    {
                        Console.WriteLine("Slide count matches extracted text count.");
                    }
                    else
                    {
                        Console.WriteLine("Slide count does NOT match extracted text count.");
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exceptions
            catch (PptxUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPT).");
            }
            // General exception handling (e.g., I/O errors, network errors)
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}