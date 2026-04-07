using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "protected.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "unprotected.ppt");

            // Define the password for the protected presentation
            string password = "myPassword";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the password‑protected presentation using LoadOptions
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = password;
                Presentation presentation = new Presentation(inputPath, loadOptions);

                // Remove encryption (password protection) if present
                if (presentation.ProtectionManager.IsEncrypted)
                {
                    presentation.ProtectionManager.RemoveEncryption();
                }

                // Remove write protection if present
                if (presentation.ProtectionManager.IsWriteProtected)
                {
                    presentation.ProtectionManager.RemoveWriteProtection();
                }

                // Save the unprotected presentation as PPT
                presentation.Save(outputPath, SaveFormat.Ppt);
                presentation.Dispose();

                Console.WriteLine("Presentation saved without password at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}