using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories relative to the current working directory
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Verify that the input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist: " + inputDirectory);
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all PPTX files in the input directory
        string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.TopDirectoryOnly);

        foreach (string pptxPath in pptxFiles)
        {
            try
            {
                // Verify the file exists before loading
                if (!File.Exists(pptxPath))
                {
                    Console.WriteLine("File not found: " + pptxPath);
                    continue;
                }

                // Load the PPTX presentation
                using (Presentation presentation = new Presentation(pptxPath))
                {
                    // Convert and save to ODP format
                    string outputFileName = Path.GetFileNameWithoutExtension(pptxPath) + ".odp";
                    string odpPath = Path.Combine(outputDirectory, outputFileName);
                    presentation.Save(odpPath, SaveFormat.Odp);

                    // Verify theme consistency after conversion
                    using (Presentation odpPresentation = new Presentation(odpPath))
                    {
                        if (presentation.MasterTheme != null && odpPresentation.MasterTheme != null)
                        {
                            // Simple consistency check: compare the count of line styles in the format scheme
                            bool themeConsistent = presentation.MasterTheme.FormatScheme.LineStyles.Count ==
                                                   odpPresentation.MasterTheme.FormatScheme.LineStyles.Count;
                            Console.WriteLine($"{outputFileName}: Theme consistency = {themeConsistent}");
                        }
                        else
                        {
                            Console.WriteLine($"{outputFileName}: Theme information missing after conversion.");
                        }
                    }
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported format
                Console.WriteLine("Unsupported format for file: " + pptxPath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);
            }
        }
    }
}