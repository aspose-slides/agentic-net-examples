using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractCleanedText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file path
            string inputPath = "input.pptx";
            // Output text file path
            string outputPath = "cleaned_text.txt";
            // Path for saving a copy of the presentation
            string savedPresentationPath = "saved_output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                return;
            }

            try
            {
                // Extract raw text using PresentationFactory with a valid extraction mode
                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    Aspose.Slides.TextExtractionArrangingMode.Arranged);

                // Build cleaned text by removing empty or whitespace-only lines
                StringBuilder cleanedBuilder = new StringBuilder();
                foreach (Aspose.Slides.ISlideText slideText in presentationText.SlidesText)
                {
                    string text = slideText.Text;
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        cleanedBuilder.AppendLine(text);
                    }
                }

                // Write the cleaned content to a text file
                File.WriteAllText(outputPath, cleanedBuilder.ToString());

                // Load the presentation and save a copy (required by the task)
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Text extraction and cleaning completed successfully.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (NotSupportedException)
            {
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}