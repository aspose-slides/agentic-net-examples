using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        var outputPath = Path.Combine(outputDir, "SignedPresentation.pptx");

        using (var presentation = new Presentation())
        {
            try
            {
                // Retrieve certificate from hardware token (example using thumbprint)
                var thumbprint = "YOUR_CERT_THUMBPRINT";
                var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                var certificate = (X509Certificate2)null;
                foreach (var cert in store.Certificates)
                {
                    if (cert.Thumbprint.Equals(thumbprint, StringComparison.OrdinalIgnoreCase))
                    {
                        certificate = cert;
                        break;
                    }
                }
                store.Close();

                if (certificate == null)
                {
                    Console.WriteLine("Certificate not found on hardware token.");
                    return;
                }

                // Create digital signature using the hardware token certificate
                var signature = new DigitalSignature(certificate);
                signature.Comments = "Signed using hardware token.";

                // Add signature to the presentation
                presentation.DigitalSignatures.Add(signature);

                // Save the signed presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation signed and saved to " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // comment that format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}