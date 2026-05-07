using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PreservePasswordExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Password for the source presentation (empty if not password‑protected)
            string password = "myPassword";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file '{inputPath}' does not exist.");
                return;
            }

            // Prepare load options with password if needed
            LoadOptions loadOptions = new LoadOptions();
            if (!string.IsNullOrEmpty(password))
            {
                loadOptions.Password = password;
            }

            try
            {
                // Load the presentation (decrypted if password is provided)
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Re‑apply encryption to preserve the original password
                    if (!string.IsNullOrEmpty(password))
                    {
                        presentation.ProtectionManager.Encrypt(password);
                    }

                    // Save the presentation in PPTX format, preserving the password
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine($"Presentation saved successfully to '{outputPath}'.");
            }
            catch (NotSupportedException)
            {
                // The requested save format is not supported
                // Format not supported
                Console.WriteLine("The requested save format is not supported.");
            }
            catch (InvalidPasswordException)
            {
                // Incorrect password supplied for a protected presentation
                Console.WriteLine("Invalid password for the input presentation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}