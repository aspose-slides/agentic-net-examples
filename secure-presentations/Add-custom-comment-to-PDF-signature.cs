// -----------------------------------------------------------------------------
// Example: Add custom comment to digital signature using C#
//
// Description:
// Demonstrates how to add a custom comment to a digital signature in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, applies a digital signature from a PFX certificate, sets a
// custom comment describing the signing purpose, and saves the signed PPTX file.
// This pattern can be used to automate signing workflows, embed metadata, or
// integrate presentation signing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Digital Signature, Custom Comment,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Add custom comments to digital signatures in PowerPoint files.
// - Automate signing of presentations with embedded metadata.
// - Build C# tools for secure presentation handling.
// - Integrate digital signing into .NET-based document workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddDigitalSignatureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the certificate and the output presentation
            string certificatePath = "testsignature1.pfx";
            string certificatePassword = "testpass1";
            string outputPresentationPath = "SignedPresentation.pptx";

            // Verify that the certificate file exists
            if (!File.Exists(certificatePath))
            {
                Console.WriteLine("Certificate file not found: " + certificatePath);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                try
                {
                    // Create a digital signature using the certificate file
                    DigitalSignature signature = new DigitalSignature(certificatePath, certificatePassword);
                    // Add a custom comment describing the signing purpose
                    signature.Comments = "Document signed for internal approval.";
                    // Add the signature to the presentation
                    presentation.DigitalSignatures.Add(signature);
                }
                catch (System.Security.Cryptography.CryptographicException cryptoEx)
                {
                    // Handle errors related to loading the certificate (e.g., wrong password or missing file)
                    Console.WriteLine("Error loading certificate: " + cryptoEx.Message);
                    return;
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException formatEx)
                {
                    // Handle unsupported file format errors
                    Console.WriteLine("Unsupported presentation format: " + formatEx.Message);
                    return;
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    return;
                }

                // Save the signed presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved with digital signature: " + outputPresentationPath);
            }
        }
    }
}
