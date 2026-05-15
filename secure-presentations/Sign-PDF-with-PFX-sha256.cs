using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the presentation, output file and the PFX certificate
        var inputPath = "input.pptx";
        var outputPath = "signed_output.pptx";
        var pfxPath = "certificate.pfx";
        var pfxPassword = "password";

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file does not exist.");
            return;
        }

        // Verify that the certificate file exists
        if (!File.Exists(pfxPath))
        {
            Console.WriteLine("Certificate file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create a digital signature using the PFX file (SHA‑256 is determined by the certificate)
                var signature = new Aspose.Slides.DigitalSignature(pfxPath, pfxPassword);
                signature.Comments = "Signed with SHA-256 certificate.";

                // Add the signature to the presentation
                presentation.DigitalSignatures.Add(signature);

                // Save the signed presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or other I/O issues
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}