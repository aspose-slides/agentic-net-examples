using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchSignPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = Path.Combine(Environment.CurrentDirectory, "Input");
            string outputDirectory = Path.Combine(Environment.CurrentDirectory, "Signed");

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            // Path to the certificate file and its password
            string certificatePath = "certificate.pfx";
            string certificatePassword = "password";

            // Verify certificate file exists
            if (!File.Exists(certificatePath))
            {
                Console.WriteLine("Certificate file not found: " + certificatePath);
                return;
            }

            // Process each PPTX file in the input directory
            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");
            foreach (string filePath in pptxFiles)
            {
                // Ensure the file still exists before processing
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found, skipping: " + filePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);

                    // Create digital signature using the certificate
                    Aspose.Slides.DigitalSignature signature = new Aspose.Slides.DigitalSignature(certificatePath, certificatePassword);
                    signature.Comments = "Signed by batch job";

                    // Add the signature to the presentation
                    presentation.DigitalSignatures.Add(signature);

                    // Save the signed presentation to the output directory
                    string fileName = Path.GetFileName(filePath);
                    string outputPath = Path.Combine(outputDirectory, fileName);
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Dispose the presentation object
                    presentation.Dispose();

                    Console.WriteLine("Signed and saved: " + outputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    Console.WriteLine("Error processing file: " + filePath);
                    Console.WriteLine("Exception: " + ex.Message);
                    // Format not supported comment
                    // Note: If the exception is due to an unsupported format, it is handled here.
                }
            }
        }
    }
}