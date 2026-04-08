using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "protected.pptx");
        string password = "myPassword";
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
        string outputPath = Path.Combine(outputDir, "decrypted.pptx");

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
            // Load the password‑protected presentation
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.Password = password;
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Modify content: add a blank slide
            Aspose.Slides.ISlideCollection slides = presentation.Slides;
            slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Remove encryption if present
            if (presentation.ProtectionManager.IsEncrypted)
            {
                presentation.ProtectionManager.RemoveEncryption();
            }

            // Save the presentation without encryption
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation decrypted and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}