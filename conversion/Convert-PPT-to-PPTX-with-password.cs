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
            // Define input and output locations
            string inputPath = @"C:\Input\legacy.ppt";
            string outputDir = @"C:\Output";
            string outputFileName = "legacy_converted.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            try
            {
                // Get presentation info to check for password protection
                IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(inputPath);
                bool isPasswordProtected = presentationInfo.IsPasswordProtected;

                // Placeholder for the password; replace with actual password if known
                string password = "myPassword";

                // Load presentation with or without password
                Presentation presentation;
                if (isPasswordProtected)
                {
                    LoadOptions loadOptions = new LoadOptions();
                    loadOptions.Password = password;
                    presentation = new Presentation(inputPath, loadOptions);
                }
                else
                {
                    presentation = new Presentation(inputPath);
                }

                // Preserve password protection by re‑encrypting if it was originally protected
                if (isPasswordProtected)
                {
                    presentation.ProtectionManager.Encrypt(password);
                }

                // Save as PPTX
                string outputPath = Path.Combine(outputDir, outputFileName);
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose presentation
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