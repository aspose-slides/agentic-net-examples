using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchRemoveTempProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory containing the presentations
            string inputDirectory = Path.Combine(Environment.CurrentDirectory, "InputPresentations");
            // Define the directory where modified presentations will be saved
            string outputDirectory = Path.Combine(Environment.CurrentDirectory, "OutputPresentations");

            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files with supported extensions
            string[] supportedExtensions = new string[] { ".pptx", ".ppt", ".odp", ".pptm" };
            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string filePath in files)
            {
                // Check if file has a supported extension
                string extension = Path.GetExtension(filePath);
                if (Array.IndexOf(supportedExtensions, extension.ToLower()) < 0)
                {
                    // Format not supported
                    // Comment: format not supported
                    continue;
                }

                if (!File.Exists(filePath))
                {
                    // File does not exist, skip
                    continue;
                }

                try
                {
                    // Load presentation with default load options
                    LoadOptions loadOptions = new LoadOptions();
                    Presentation presentation = new Presentation(filePath, loadOptions);

                    // Access document properties
                    IDocumentProperties documentProperties = presentation.DocumentProperties;

                    // Iterate backwards to safely remove properties
                    for (int i = documentProperties.CountOfCustomProperties - 1; i >= 0; i--)
                    {
                        string propertyName = documentProperties.GetCustomPropertyName(i);
                        if (propertyName != null && propertyName.StartsWith("Temp_"))
                        {
                            documentProperties.RemoveCustomProperty(propertyName);
                        }
                    }

                    // Save modified presentation
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(filePath));
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    presentation.Dispose();
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., loading errors, unsupported format)
                    Console.WriteLine("Error processing file: " + filePath);
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }
}