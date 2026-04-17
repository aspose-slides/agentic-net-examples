using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Set password to open the presentation (AES‑256 encryption is applied by default)
        string password = "MySecurePassword123!";
        presentation.ProtectionManager.Encrypt(password);

        // Save the presentation
        string outputPath = Path.Combine(outputDir, "ProtectedPresentation.pptx");
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();

        Console.WriteLine("Presentation saved with password protection at: " + outputPath);
    }
}