using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input presentation path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Define output directory and ensure it exists
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Password for encryption
        string password = "myPassword";

        try
        {
            // Load the presentation (which may contain media files)
            Presentation presentation = new Presentation(inputPath);

            // Encrypt the presentation with the specified password
            presentation.ProtectionManager.Encrypt(password);

            // Save the encrypted presentation
            string outputPath = Path.Combine(outputDir, "encrypted.pptx");
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation encrypted and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("An error occurred: " + ex.Message);
            // format not supported
        }
    }
}