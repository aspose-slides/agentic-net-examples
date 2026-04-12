using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractLayoutText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "layout_text.txt";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Extract raw text using PresentationFactory with a valid extraction mode
                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                // Concatenate layout text from all slides
                string concatenatedLayoutText = string.Empty;
                ISlideText[] slidesTextArray = presentationText.SlidesText;
                for (int i = 0; i < slidesTextArray.Length; i++)
                {
                    ISlideText slideText = slidesTextArray[i];
                    if (!string.IsNullOrEmpty(slideText.LayoutText))
                    {
                        concatenatedLayoutText += slideText.LayoutText + Environment.NewLine;
                    }
                }

                // Write the concatenated text to a TXT file
                File.WriteAllText(outputPath, concatenatedLayoutText);
                Console.WriteLine("Layout text extracted to: " + outputPath);

                // Load the presentation to save it before exiting (as per requirement)
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save the presentation (could be to the same file or a copy)
                    string savedPath = "saved_copy.pptx";
                    presentation.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Comment: format not supported (PPTX)
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Comment: format not supported (PPT)
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}