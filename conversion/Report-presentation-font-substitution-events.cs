using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the folder containing presentations
        string folderPath = "Presentations";

        // Verify the folder exists
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Folder does not exist: " + folderPath);
            return;
        }

        // Get all files in the folder
        string[] presentationFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string filePath in presentationFiles)
        {
            // Check if the file format is supported
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (extension != ".pptx" && extension != ".ppt" && extension != ".pptm")
            {
                // Format not supported
                // Comment: format not supported
                continue;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                bool hasSubstitution = false;

                // Iterate over font substitutions
                foreach (Aspose.Slides.FontSubstitutionInfo fontSubstitution in pres.FontsManager.GetSubstitutions())
                {
                    hasSubstitution = true;
                    Console.WriteLine($"{Path.GetFileName(filePath)}: {fontSubstitution.OriginalFontName} -> {fontSubstitution.SubstitutedFontName}");
                }

                // Save the presentation before exiting (no modifications made)
                pres.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., loading issues)
                Console.WriteLine($"Error processing {filePath}: {ex.Message}");
            }
        }
    }
}