// -----------------------------------------------------------------------------
// Example: Configure hardware token signature provider for PPTX using C#
//
// Description:
// Demonstrates how to configure a hardware token digital signature provider 
// for a PPTX file using C# and Aspose.Slides for .NET. The example loads an 
// existing presentation, retrieves a certificate from a hardware token via the 
// Windows certificate store, applies a digital signature, and saves the signed 
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hardware Token, Digital Signature, 
// Certificate Store, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate signing PPTX files with a hardware token certificate.
// - Build C# utilities for secure PowerPoint document handling.
// - Integrate digital signing into .NET applications that process presentations.
// - Ensure authenticity and integrity of PPTX files before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SecurePresentationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "signed_output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation from the file
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Open the user's personal certificate store to locate the hardware token certificate
                    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    store.Open(OpenFlags.ReadOnly);

                    // Replace the thumbprint with the actual thumbprint of the hardware token certificate
                    X509Certificate2Collection certs = store.Certificates.Find(
                        X509FindType.FindByThumbprint,
                        "YOUR_CERT_THUMBPRINT",
                        false);

                    if (certs.Count == 0)
                    {
                        Console.WriteLine("Certificate not found in hardware token.");
                        return;
                    }

                    // Use the first matching certificate
                    X509Certificate2 cert = certs[0];

                    // Create a digital signature using the certificate
                    Aspose.Slides.DigitalSignature signature = new Aspose.Slides.DigitalSignature(cert);
                    signature.Comments = "Signed with hardware token.";

                    // Add the signature to the presentation
                    pres.DigitalSignatures.Add(signature);

                    // Save the signed presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported comment
                Console.WriteLine("PPTX format not supported: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Format not supported comment
                Console.WriteLine("PPT format not supported: " + ex.Message);
            }
            // General exception handling (including possible web service errors)
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
