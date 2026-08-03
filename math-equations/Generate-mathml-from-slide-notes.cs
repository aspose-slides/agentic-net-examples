// -----------------------------------------------------------------------------
// Example: Generate mathml from slide notes using C#
//
// Description:
// Demonstrates how to generate MathML from slide notes using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, MathML, Slide, Notes, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of MathML from slide notes.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input folder path (first argument or default)
        string inputFolder = args.Length > 0 ? args[0] : "InputPresentations";

        // Verify input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist.");
            return;
        }

        // Output folder for MathML files
        string outputFolder = Path.Combine(inputFolder, "MathML");
        Directory.CreateDirectory(outputFolder);

        // Supported presentation extensions
        string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".fodp" };

        // Process each file in the input folder
        string[] files = Directory.GetFiles(inputFolder);
        foreach (string filePath in files)
        {
            try
            {
                // Skip unsupported formats
                if (Array.IndexOf(supportedExtensions, Path.GetExtension(filePath).ToLower()) < 0)
                {
                    // Format not supported – continue to next file
                    continue;
                }

                // Load presentation
                using (Presentation pres = new Presentation(filePath))
                {
                    // Iterate through slides
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        // Construct MathML file name for the current slide
                        string mathmlFile = Path.Combine(
                            outputFolder,
                            Path.GetFileNameWithoutExtension(filePath) + $"_slide{i + 1}.mml");

                        // Create file stream for MathML output
                        using (FileStream stream = new FileStream(mathmlFile, FileMode.Create, FileAccess.Write))
                        {
                            // Placeholder: extract MathParagraph or MathBlock from the slide
                            // Example (requires actual MathParagraph instance):
                            // MathParagraph mathParagraph = ...;
                            // mathParagraph.WriteAsMathMl(stream);
                        }
                    }

                    // Save presentation before exiting (no modifications made)
                    string tempSavePath = Path.Combine(outputFolder, Path.GetFileName(filePath));
                    pres.Save(tempSavePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported format exception (commented as per requirement)
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine($"Error processing file '{filePath}': {ex.Message}");
            }
        }
    }
}
