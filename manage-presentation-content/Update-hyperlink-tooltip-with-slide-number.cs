using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output directories
        string inputDir = Path.Combine(Environment.CurrentDirectory, "InputPresentations");
        string outputBaseDir = Path.Combine(Environment.CurrentDirectory, "OrganizedPresentations");
        if (!Directory.Exists(outputBaseDir))
            Directory.CreateDirectory(outputBaseDir);

        // List of presentation files to process
        string[] presentationFiles = new string[]
        {
            Path.Combine(inputDir, "Pres1.pptx"),
            Path.Combine(inputDir, "Pres2.pptx")
        };

        foreach (string filePath in presentationFiles)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                continue;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(filePath))
                {
                    // Retrieve the Category property
                    IDocumentProperties docProps = pres.DocumentProperties;
                    string category = docProps.Category;
                    if (string.IsNullOrEmpty(category))
                        category = "Uncategorized";

                    // Create target folder based on category
                    string targetDir = Path.Combine(outputBaseDir, category);
                    if (!Directory.Exists(targetDir))
                        Directory.CreateDirectory(targetDir);

                    // Define destination path
                    string fileName = Path.GetFileName(filePath);
                    string destPath = Path.Combine(targetDir, fileName);

                    // Save the presentation to the destination folder
                    pres.Save(destPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported formats or other errors
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }
    }
}