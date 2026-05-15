using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the certificate and output file
        string pfxPath = "testsignature1.pfx";
        string pfxPassword = "testpass1";
        string outputPath = "SignedPresentation.pptx";

        // Verify that the certificate file exists
        if (!System.IO.File.Exists(pfxPath))
        {
            Console.WriteLine("Certificate file not found: " + pfxPath);
            return;
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create a digital signature with a custom comment
        Aspose.Slides.DigitalSignature signature = new Aspose.Slides.DigitalSignature(pfxPath, pfxPassword);
        signature.Comments = "Document signed for approval.";

        // Add the signature to the presentation
        presentation.DigitalSignatures.Add(signature);

        // Save the signed presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved with digital signature.");
        }
        catch (Exception ex)
        {
            // Handle format not supported or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation object
        presentation.Dispose();
    }
}