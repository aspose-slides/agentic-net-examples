using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Create or load a presentation
        Presentation presentation;
        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }
        }
        else
        {
            presentation = new Presentation();
        }

        // Set a decorative flag (read‑only recommendation)
        presentation.ProtectionManager.ReadOnlyRecommended = true;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors (e.g., unsupported format)
            Console.WriteLine("Failed to save presentation: " + ex.Message);
            presentation.Dispose();
            return;
        }
        presentation.Dispose();

        // Reload the saved presentation and verify the flag persists
        try
        {
            Presentation reloaded = new Presentation(outputPath);
            bool flagPersisted = reloaded.ProtectionManager.ReadOnlyRecommended;
            Console.WriteLine("ReadOnlyRecommended flag persisted: " + flagPersisted);
            reloaded.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to reload presentation: " + ex.Message);
        }
    }
}