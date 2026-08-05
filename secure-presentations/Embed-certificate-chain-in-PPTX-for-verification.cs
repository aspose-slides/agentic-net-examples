// -----------------------------------------------------------------------------
// Example: Embed certificate chain in PPTX for verification using C#
//
// Description:
// Demonstrates how to embed a full certificate chain into a PowerPoint
// presentation (PPTX) using Aspose.Slides for .NET. The example creates a new
// presentation, applies a digital signature from a PFX file (including the
// certificate chain), and saves the signed file. This pattern can be used to
// ensure PPTX files can be verified later using standard digital signature
// validation tools.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Embed, Certificate, Chain,
// DigitalSignature, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate embedding of a certificate chain in PPTX files for later verification.
// - Build .NET utilities that sign PowerPoint presentations programmatically.
// - Ensure compliance and authenticity of distributed PPTX documents.
// - Integrate digital signing into PowerPoint workflow automation.
// -----------------------------------------------------------------------------
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
            try
            {
                // Define paths
                string currentDirectory = Directory.GetCurrentDirectory();
                string outputDirectory = Path.Combine(currentDirectory, "Output");
                string certificatePath = Path.Combine(currentDirectory, "certificate.pfx");
                string certificatePassword = "yourPassword";

                // Ensure output directory exists
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Verify certificate file exists
                if (!File.Exists(certificatePath))
                {
                    Console.WriteLine("Certificate file not found: " + certificatePath);
                    return;
                }

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Create digital signature using the PFX file and password
                DigitalSignature signature = new DigitalSignature(certificatePath, certificatePassword);
                signature.Comments = "Signed with full certificate chain.";

                // Add the signature to the presentation
                presentation.DigitalSignatures.Add(signature);

                // Save the signed presentation
                string outputPath = Path.Combine(outputDirectory, "SignedPresentation.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);

                Console.WriteLine("Presentation signed and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
