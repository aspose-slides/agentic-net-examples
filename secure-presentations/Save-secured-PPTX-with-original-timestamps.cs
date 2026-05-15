using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        // Password to secure the presentation
        string password = "securePassword";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Preserve original timestamps and metadata
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
            DateTime originalLastSaved = documentProperties.LastSavedTime;

            // Do not encrypt document properties to keep metadata readable
            presentation.ProtectionManager.EncryptDocumentProperties = false;
            // Encrypt the presentation with the specified password
            presentation.ProtectionManager.Encrypt(password);

            // Restore original timestamp after encryption
            documentProperties.LastSavedTime = originalLastSaved;

            // Save the secured presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}