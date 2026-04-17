using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSlideText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

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
                    // Extract raw text from all slides using Unarranged mode
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        inputPath,
                        TextExtractionArrangingMode.Unarranged);

                    // Build a plain‑text summary
                    StringBuilder summaryBuilder = new StringBuilder();
                    foreach (ISlideText slideText in presentationText.SlidesText)
                    {
                        summaryBuilder.AppendLine(slideText.Text);
                    }

                    // Write the summary to a text file
                    string outputTextPath = "summary.txt";
                    File.WriteAllText(outputTextPath, summaryBuilder.ToString());
                    Console.WriteLine("Text summary written to: " + outputTextPath);

                    // Save the presentation before exiting (copy to a new file)
                    string savedPresentationPath = "output_copy.pptx";
                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + savedPresentationPath);
                }
            }
            // Handle unsupported file format exceptions
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            // Handle any other exceptions (e.g., I/O errors)
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}