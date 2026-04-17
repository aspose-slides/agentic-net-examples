using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdatePasswordExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths and passwords
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "protected.pptx");
            string oldPassword = "oldPass";
            string newPassword = "newPass";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation with the existing password
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = oldPassword;
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath, loadOptions);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to open presentation: " + ex.Message);
                return;
            }

            // Set the new opening password
            presentation.ProtectionManager.Encrypt(newPassword);

            // Prepare output directory and file path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            string outputPath = Path.Combine(outputDir, "protected_updated.pptx");

            // Save the presentation with the new password
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved with new password at: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}