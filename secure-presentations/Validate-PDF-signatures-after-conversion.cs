using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DigitalSignatureVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input file path and output file path
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Usage: DigitalSignatureVerification <input-pptx> <output-pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePresentation = new Presentation(inputPath))
                {
                    // Save the presentation in the desired format (example: PPTX)
                    sourcePresentation.Save(outputPath, SaveFormat.Pptx);
                }

                // After conversion, load the saved presentation to verify digital signatures
                using (Presentation convertedPresentation = new Presentation(outputPath))
                {
                    int signatureCount = convertedPresentation.DigitalSignatures.Count;
                    if (signatureCount == 0)
                    {
                        Console.WriteLine("No digital signatures found in the converted presentation.");
                    }
                    else
                    {
                        bool allValid = true;
                        Console.WriteLine("Digital signatures in the converted presentation:");
                        foreach (DigitalSignature signature in convertedPresentation.DigitalSignatures)
                        {
                            string subject = signature.Certificate.SubjectName.Name;
                            string signTime = signature.SignTime.ToString("yyyy-MM-dd HH:mm");
                            string validity = signature.IsValid ? "VALID" : "INVALID";
                            Console.WriteLine($"{subject}, {signTime} -- {validity}");
                            allValid &= signature.IsValid;
                        }

                        if (allValid)
                        {
                            Console.WriteLine("All signatures are valid. Presentation is genuine.");
                        }
                        else
                        {
                            Console.WriteLine("One or more signatures are invalid. Presentation may have been modified.");
                        }
                    }
                }
            }
            // Handle unsupported file format exceptions specific to Aspose.Slides
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            // Handle generic not supported exceptions (e.g., unsupported save format)
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Operation not supported: " + ex.Message);
            }
            // Catch any other unexpected exceptions
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}