using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file (password protected)
            string inputFile = "protected.ppt";
            // Output PPTX file (password removed)
            string outputFile = "unprotected.pptx";
            // Password to open the protected PPT
            string password = "myPassword";

            // Verify input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                // Load the password‑protected presentation
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = password;
                Presentation presentation = new Presentation(inputFile, loadOptions);

                // Remove write protection if present
                if (presentation.ProtectionManager.IsWriteProtected)
                {
                    presentation.ProtectionManager.RemoveWriteProtection();
                }

                // Remove encryption (open password) if present
                if (presentation.ProtectionManager.IsEncrypted)
                {
                    presentation.ProtectionManager.RemoveEncryption();
                }

                // Save as PPTX without any protection
                presentation.Save(outputFile, SaveFormat.Pptx);
                Console.WriteLine("Presentation converted and password removed: " + outputFile);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}