using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesPasswordChange
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input PPT file path
            string inputFileName = "input.ppt";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Define output directory and ensure it exists
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define new password for the presentation
            string newPassword = "SecurePassphrase123!";

            try
            {
                // Load the PPT presentation
                Presentation presentation = new Presentation(inputPath);

                // Encrypt the presentation with the new password
                presentation.ProtectionManager.Encrypt(newPassword);

                // Save the presentation as PPTX with the new password
                string outputFileName = "output.pptx";
                string outputPath = Path.Combine(outputDir, outputFileName);
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation converted and password changed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}