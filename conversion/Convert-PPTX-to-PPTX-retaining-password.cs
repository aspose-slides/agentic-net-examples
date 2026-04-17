using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxRetainPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            // Password for the protected presentation
            string password = "myPassword";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file '{inputPath}' does not exist.");
                return;
            }

            try
            {
                // Set load options with the password
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = password;

                // Open the password‑protected presentation
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Re‑apply the same password to retain protection
                    presentation.ProtectionManager.Encrypt(password);

                    // Save the presentation in PPTX format
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine($"Presentation saved successfully to '{outputPath}'.");
            }
            catch (InvalidPasswordException)
            {
                Console.WriteLine("The provided password is incorrect.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}