using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesDigitalSignatureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPdfPath = "output.pdf";
            string certificatePath = "signature.pfx";
            string certificatePassword = "password";
            string signatureComments = "Signature for stakeholders.";

            // Verify input file exists
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
                    // Add digital signature to the presentation
                    DigitalSignature signature = new DigitalSignature(certificatePath, certificatePassword);
                    signature.Comments = signatureComments;
                    presentation.DigitalSignatures.Add(signature);

                    // Save the signed presentation as PDF
                    presentation.Save(outputPdfPath, SaveFormat.Pdf);
                }

                Console.WriteLine("Presentation converted to PDF with digital signature successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // The provided format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}