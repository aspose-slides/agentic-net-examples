using System;
using System.IO;
using Aspose.Slides.Export;

namespace RemoveDigitalSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Remove all digital signatures if present
                    if (presentation.DigitalSignatures.Count > 0)
                    {
                        // The collection implements IList, so Clear removes all signatures
                        presentation.DigitalSignatures.Clear();
                    }

                    // Save the presentation preserving other protections
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for saving.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}