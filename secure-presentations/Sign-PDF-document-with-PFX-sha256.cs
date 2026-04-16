using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation, output file and certificate details
        string inputPath = "input.pptx";
        string outputPath = "signed_output.pptx";
        string pfxPath = "certificate.pfx";
        string pfxPassword = "password";

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Verify that the certificate file exists
        if (!File.Exists(pfxPath))
        {
            Console.WriteLine("Certificate file does not exist: " + pfxPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create a digital signature using the PFX certificate (SHA‑256 is used by the certificate)
            Aspose.Slides.DigitalSignature signature = new Aspose.Slides.DigitalSignature(pfxPath, pfxPassword);
            signature.Comments = "Signed with SHA-256 certificate.";

            // Add the signature to the presentation
            presentation.DigitalSignatures.Add(signature);

            // Save the signed presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation signed and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle accordingly
            // format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}