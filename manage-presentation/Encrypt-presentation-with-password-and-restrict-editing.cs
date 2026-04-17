using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationProtectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define passwords
            string openPassword = "Open123!";
            string editPassword = "Edit123!";

            // Define output folder and file
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "ProtectedPresentations");
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            string outputPath = Path.Combine(outputFolder, "encrypted_write_protected.pptx");

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Encrypt the presentation with an open password
                presentation.ProtectionManager.Encrypt(openPassword);

                // Set write protection to restrict editing
                presentation.ProtectionManager.SetWriteProtection(editPassword);

                // Save the protected presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully at: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // If the format is not supported, Aspose.Slides will throw an exception.
            }
        }
    }
}