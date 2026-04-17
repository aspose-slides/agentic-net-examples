using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DecryptPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path and password
            string inputPath = "encrypted.pptx";
            string password = "123123";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output directory and file
            string outputDir = "output";
            string outputFileName = "decrypted.pptx";

            try
            {
                // Load encrypted presentation with password
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = password;
                Presentation presentation = new Presentation(inputPath, loadOptions);

                // Display encryption information
                Console.WriteLine("Encryption Password: " + presentation.ProtectionManager.EncryptionPassword);
                Console.WriteLine("Is Encrypted: " + presentation.ProtectionManager.IsEncrypted);

                // Access custom data (placeholder - actual implementation depends on ICustomData API)
                // Example: Console.WriteLine("Custom Data: " + presentation.CustomData.ToString());

                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Save decrypted presentation (optionally re‑encrypt with a new password)
                string outputPath = Path.Combine(outputDir, outputFileName);
                // Re‑encrypt with a new password if desired; otherwise comment out the next line
                // presentation.ProtectionManager.Encrypt("newPassword");
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}