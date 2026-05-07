using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output settings
        string inputPath = "protected.pptx";
        string outputDir = "output";
        string outputFileName = "unprotected.ppt";
        string password = "myPassword";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load password‑protected presentation
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = password;
            Presentation presentation = new Presentation(inputPath, loadOptions);

            // Remove encryption if present
            if (presentation.ProtectionManager.IsEncrypted)
            {
                presentation.ProtectionManager.RemoveEncryption();
            }

            // Remove write protection if present
            if (presentation.ProtectionManager.IsWriteProtected)
            {
                presentation.ProtectionManager.RemoveWriteProtection();
            }

            // Save unprotected presentation as PPT
            string outputPath = Path.Combine(outputDir, outputFileName);
            presentation.Save(outputPath, SaveFormat.Ppt);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}