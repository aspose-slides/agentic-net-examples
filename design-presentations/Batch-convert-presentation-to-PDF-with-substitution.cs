using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string inputDirectory = "InputPresentations";
        string outputDirectory = "OutputPDFs";

        // Verify input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist: " + inputDirectory);
            return;
        }

        // Create output directory if it does not exist
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Supported presentation file extensions
        string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pot", ".potx", ".pptm", ".otp" };

        // Process each file in the input directory
        string[] files = Directory.GetFiles(inputDirectory);
        foreach (string filePath in files)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            // Skip unsupported formats
            if (Array.IndexOf(supportedExtensions, extension) < 0)
            {
                Console.WriteLine("Skipping unsupported file format: " + filePath);
                continue;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(filePath))
                {
                    // Create a font substitution rule for missing fonts
                    IFontData sourceFont = new FontData("Arial");
                    IFontData destinationFont = new FontData("Times New Roman");
                    FontSubstRule substitutionRule = new FontSubstRule(sourceFont, destinationFont, FontSubstCondition.WhenInaccessible);
                    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
                    substitutionRules.Add(substitutionRule);
                    presentation.FontsManager.FontSubstRuleList = substitutionRules;

                    // Configure PDF options (set default regular font as fallback)
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.DefaultRegularFont = "Arial";

                    // Determine output PDF path
                    string outputFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".pdf");

                    // Save the presentation as PDF
                    presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                    Console.WriteLine("Converted: " + filePath + " -> " + outputFilePath);
                }
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format or I/O issues
                Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
            }
        }
    }
}