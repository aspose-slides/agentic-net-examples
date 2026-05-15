using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DigitalSignatureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            // Define certificate (PFX) path and password
            string pfxPath = Path.Combine(Directory.GetCurrentDirectory(), "certchain.pfx");
            string pfxPassword = "yourPfxPassword";
            if (!File.Exists(pfxPath))
            {
                Console.WriteLine("Certificate file not found: " + pfxPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Create digital signature with full certificate chain
                DigitalSignature signature = new DigitalSignature(pfxPath, pfxPassword);
                signature.Comments = "Signed with full certificate chain.";

                // Add signature to the presentation
                presentation.DigitalSignatures.Add(signature);

                // Save signed presentation
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SignedPresentation.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation signed and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}