using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputTextPath = "combined_output.txt";
            string outputPresentationPath = "output_copy.pptx";

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
                    // Extract raw text from the presentation using a valid extraction mode
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        inputPath,
                        Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                    // Retrieve master slide text (assumed to be the same for all slides)
                    string masterText = string.Empty;
                    if (presentationText.SlidesText.Length > 0)
                    {
                        masterText = presentationText.SlidesText[0].MasterText;
                    }

                    // Build combined text for each slide
                    StringBuilder combinedBuilder = new StringBuilder();
                    foreach (ISlideText slideText in presentationText.SlidesText)
                    {
                        combinedBuilder.AppendLine(masterText);
                        combinedBuilder.AppendLine(slideText.Text);
                        combinedBuilder.AppendLine("---"); // Separator between slides
                    }

                    // Write the combined output to a text file
                    File.WriteAllText(outputTextPath, combinedBuilder.ToString());

                    // Save a copy of the presentation before exiting (no modifications made)
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The provided file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The provided file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}