using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input file path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "protected.ppt");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Password for the protected presentation
        string password = "myPassword";

        try
        {
            // Load the password‑protected presentation
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = password;
            Presentation presentation = new Presentation(inputPath, loadOptions);

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Save as PPTX
            string outputPath = Path.Combine(outputDir, "converted.pptx");
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();

            Console.WriteLine("Presentation converted successfully.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}