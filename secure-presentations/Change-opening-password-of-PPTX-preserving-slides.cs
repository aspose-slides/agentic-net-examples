using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdatePresentationPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths and passwords
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "protected.pptx");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            string outputFilePath = Path.Combine(outputDirectory, "protected_updated.pptx");
            string oldPassword = "oldPass123";
            string newPassword = "newPass456";

            // Check if input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file does not exist: " + inputFilePath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Open the password-protected presentation
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = oldPassword;
                Presentation presentation = new Presentation(inputFilePath, loadOptions);

                // Set a new opening password
                presentation.ProtectionManager.Encrypt(newPassword);

                // Save the presentation with the new password
                presentation.Save(outputFilePath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Password updated successfully. Saved to: " + outputFilePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., incorrect password, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}