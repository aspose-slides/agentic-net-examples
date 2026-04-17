using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data";
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";
        string inputPath = Path.Combine(dataDir, inputFile);
        string outputPath = Path.Combine(dataDir, outputFile);

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Extract the creation date from document properties
                Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
                DateTime creationDate = documentProperties.CreatedTime;

                // Iterate through each slide and set the footer text
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[i].HeaderFooterManager;

                    // Ensure the footer placeholder is visible
                    if (!headerFooterManager.IsFooterVisible)
                    {
                        headerFooterManager.SetFooterVisibility(true);
                    }

                    // Set the footer text to the creation date
                    headerFooterManager.SetFooterText(creationDate.ToString("yyyy-MM-dd"));
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}