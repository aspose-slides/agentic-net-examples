using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Determine encryption status
            bool isEncrypted = presentation.ProtectionManager.IsEncrypted;

            // Add a custom document property indicating encryption status
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
            documentProperties["IsEncrypted"] = isEncrypted;

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}