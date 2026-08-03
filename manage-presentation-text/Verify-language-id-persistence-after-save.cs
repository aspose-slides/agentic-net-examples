// -----------------------------------------------------------------------------
// Example: Verify language id persistence after save using C#
//
// Description:
// Demonstrates how to verify language id persistence after save using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Language, Persistence, 
// After, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate verify language id persistence after save.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LanguageIdPersistenceTest
{
    class Program
    {
        static void Main()
        {
            // Define file name and ensure output directory exists
            var outputFileName = "LanguageIdPersistence.pptx";
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);
            var outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a new presentation and add a rectangle shape with text
            var pres = new Presentation();
            var shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 50);
            shape.AddTextFrame("Sample Text");
            // Set the language ID for the first portion
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-US";

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();

            // Reload the presentation and verify the language ID persists
            try
            {
                var loadedPres = new Presentation(outputPath);
                var loadedShape = (IAutoShape)loadedPres.Slides[0].Shapes[0];
                var persistedLanguageId = loadedShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId;

                // Simple assertion
                if (persistedLanguageId != "en-US")
                    throw new Exception("LanguageId did not persist after saving and reloading.");

                loadedPres.Dispose();
                Console.WriteLine("LanguageId persistence test passed.");
            }
            catch (Exception ex) when (ex is NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
