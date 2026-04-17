using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ClearFontSubstitution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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
                    // Clear all font substitution rules
                    Aspose.Slides.IFontSubstRuleCollection emptySubstRules = new Aspose.Slides.FontSubstRuleCollection();
                    presentation.FontsManager.FontSubstRuleList = emptySubstRules;

                    // Save the presentation (ensure SaveFormat is referenced from Aspose.Slides.Export)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, network issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}