using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesDigitalSignaturePdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string signedPptxPath = "signed.pptx";
            string outputPdfPath = "output.pdf";
            string certificatePath = "cert.pfx";
            string certificatePassword = "password";

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
                    // Create digital signature from PFX file
                    DigitalSignature signature = new DigitalSignature(certificatePath, certificatePassword);
                    // Add comment to the signature
                    signature.Comments = "Signature for stakeholders.";
                    // Add the signature to the presentation
                    presentation.DigitalSignatures.Add(signature);

                    // Save the signed presentation (optional, for reference)
                    presentation.Save(signedPptxPath, SaveFormat.Pptx);

                    // Convert the signed presentation to PDF
                    presentation.Save(outputPdfPath, SaveFormat.Pdf);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}