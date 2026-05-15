using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define file paths and password
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        string outputPath = Path.Combine(outputDir, "protected.pptx");
        string password = "MyStrongPassword";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            // Encrypt with password (AES‑256 is used by default)
            presentation.ProtectionManager.Encrypt(password);
            // Save encrypted presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
            Console.WriteLine("Presentation saved with password protection.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}