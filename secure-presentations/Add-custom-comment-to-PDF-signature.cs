// -----------------------------------------------------------------------------
// Example: Add custom comment to digital signature using C#
//
// Description:
// Demonstrates how to add a custom comment to a digital signature in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PPTX files and produces a signed presentation
// as output in a standalone console application. Developers can use this pattern
// to automate PPTX workflows, validate results, or integrate presentation logic
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Digital Signature, Custom Comment,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a custom comment to a digital signature in PowerPoint files.
// - Build C# tools for PowerPoint presentation processing and signing.
// - Generate or transform PPTX files with embedded signatures in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
