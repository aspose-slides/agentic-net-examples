// -----------------------------------------------------------------------------
// Example: Batch sign PPTX presentations with certificate using C#
//
// Description:
// Demonstrates how to batch sign PPTX presentations located in a directory
// using a PFX certificate with Aspose.Slides for .NET. The example loads each
// PPTX file, applies a digital signature, and overwrites the original file.
// This pattern can be used to automate signing of PowerPoint files in
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Sign, Certificate,
// DigitalSignature, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch signing of PPTX presentations with a digital certificate.
// - Build C# utilities for secure PowerPoint document distribution.
// - Integrate digital signing into .NET PowerPoint workflow pipelines.
// - Ensure authenticity and integrity of PPTX files before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchSign
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory containing PPTX files
            string inputDir = @"C:\Presentations";
            // Path to the PFX certificate and its password
            string certPath = @"C:\certs\mycert.pfx";
            string certPassword = "certPass";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist.");
                return;
            }

            // Retrieve all PPTX files in the directory
            string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");
            foreach (string filePath in pptxFiles)
            {
                try
                {
                    // Load the presentation
                    Presentation presentation = new Presentation(filePath);

                    // Create a digital signature using the certificate
                    DigitalSignature signature = new DigitalSignature(certPath, certPassword);
                    signature.Comments = "Signed by batch process.";

                    // Add the signature to the presentation
                    presentation.DigitalSignatures.Add(signature);

                    // Save the signed presentation (overwrite original)
                    presentation.Save(filePath, SaveFormat.Pptx);

                    // Release resources
                    presentation.Dispose();

                    Console.WriteLine($"Signed: {Path.GetFileName(filePath)}");
                }
                catch (Exception ex)
                {
                    // Handle errors (e.g., unsupported format)
                    Console.WriteLine($"Failed to sign {Path.GetFileName(filePath)}: {ex.Message}");
                    // Format not supported.
                }
            }
        }
    }
}
