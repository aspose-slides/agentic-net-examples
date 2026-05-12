using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        string password = "myPassword";

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Restrict editing by setting write protection
            presentation.ProtectionManager.SetWriteProtection(password);

            // Encrypt the presentation with the same password
            presentation.ProtectionManager.Encrypt(password);

            // Save the protected presentation
            string outputPath = Path.Combine(outputDir, "protected.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Presentation saved with encryption and write protection.");
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}