using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertLegacyPpt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path
            string inputPath = "legacy.ppt";
            // Output directory and file name
            string outputDir = "Converted";
            string outputFileName = "converted.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Full output path
            string outputPath = Path.Combine(outputDir, outputFileName);

            try
            {
                // Get presentation info to check for password protection
                IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(inputPath);
                bool isPasswordProtected = presentationInfo.IsPasswordProtected;

                // Placeholder password (replace with actual password if needed)
                string password = "your_password";

                Presentation presentation;

                if (isPasswordProtected)
                {
                    // Load with password
                    LoadOptions loadOptions = new LoadOptions();
                    loadOptions.Password = password;
                    presentation = new Presentation(inputPath, loadOptions);
                    // Re‑encrypt with the same password to preserve protection
                    presentation.ProtectionManager.Encrypt(password);
                }
                else
                {
                    // Load without password
                    presentation = new Presentation(inputPath);
                }

                // Save as PPTX
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}