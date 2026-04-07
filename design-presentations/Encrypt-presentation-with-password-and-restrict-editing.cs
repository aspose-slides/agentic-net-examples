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
            // Define output directory and file name
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Define passwords
            string writeProtectionPassword = "EditPass123";
            string encryptionPassword = "OpenPass123";

            // Create a new presentation, set write protection, and save
            Presentation pres = new Presentation();
            pres.ProtectionManager.SetWriteProtection(writeProtectionPassword);
            string protectedPath = Path.Combine(outputDir, "write_protected.pptx");
            pres.Save(protectedPath, SaveFormat.Pptx);
            pres.Dispose();

            // Load the write-protected presentation, encrypt it, and save (overwrites the same file)
            try
            {
                Presentation encryptedPres = new Presentation(protectedPath);
                encryptedPres.ProtectionManager.Encrypt(encryptionPassword);
                encryptedPres.Save(protectedPath, SaveFormat.Pptx);
                encryptedPres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format or encryption errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}