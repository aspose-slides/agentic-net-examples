using System;
using System.IO;
using System.Text;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "sample.pptx";

            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Extract raw text from each slide using the Unarranged mode
                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                Aspose.Slides.ISlideText[] slidesText = presentationText.SlidesText;

                // Save each slide's text to a separate UTF‑8 encoded file
                for (int i = 0; i < slidesText.Length; i++)
                {
                    string slideContent = slidesText[i].Text ?? string.Empty;
                    string outputFile = $"slide_{i + 1}.txt";
                    File.WriteAllText(outputFile, slideContent, Encoding.UTF8);
                }

                // Load the presentation and save it (required by the rule to save before exit)
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}