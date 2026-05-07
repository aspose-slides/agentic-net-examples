using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationPasswordChange
{
    class Program
    {
        static void Main()
        {
            // Define input PPT file path
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.ppt");
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Define output directory and file path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            string outputFile = Path.Combine(outputDir, "output.pptx");

            // New password to set
            string newPassword = "NewSecurePassphrase123!";

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputFile);

                // Set new password
                presentation.ProtectionManager.Encrypt(newPassword);

                // Save as PPTX with the new password
                presentation.Save(outputFile, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}