using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define file paths
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        var outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        var outputPath = Path.Combine(outputDir, "protected.pptx");
        // Password meeting minimum 12 characters and mixed case requirement
        var password = "SecurePass123";

        // Check if input file exists; create a new presentation if it does not
        if (!File.Exists(inputPath))
        {
            var newPresentation = new Presentation();
            // Ensure output directory exists for initial save
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            newPresentation.Save(inputPath, SaveFormat.Pptx);
            newPresentation.Dispose();
        }

        try
        {
            // Load the presentation (no password needed for unprotected file)
            var loadOptions = new LoadOptions();
            var presentation = new Presentation(inputPath, loadOptions);

            // Apply write protection with the specified password
            presentation.ProtectionManager.SetWriteProtection(password);
            // Encrypt the presentation with the same password for opening
            presentation.ProtectionManager.Encrypt(password);

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Save the password-protected presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}