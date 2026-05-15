using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveDigitalSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "SignedPresentation.pptx";
            string outputPath = "UnsignedPresentation.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                LoadOptions loadOptions = new LoadOptions();
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Remove all digital signatures if any are present
                    if (presentation.DigitalSignatures.Count > 0)
                    {
                        presentation.DigitalSignatures.Clear();
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Digital signatures removed and presentation saved to: " + outputPath);
            }
            // Handle specific unsupported format exceptions
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}