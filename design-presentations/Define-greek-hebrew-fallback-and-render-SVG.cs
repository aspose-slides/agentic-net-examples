using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackSvgExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputFolder = "output";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Create fallback rules collection
                    IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();

                    // Greek range fallback rule
                    rules.Add(new FontFallBackRule(0x0370, 0x03FF, "Arial"));

                    // Hebrew range fallback rule
                    rules.Add(new FontFallBackRule(0x0590, 0x05FF, "Times New Roman"));

                    // Assign the rules to the presentation's FontsManager
                    pres.FontsManager.FontFallBackRulesCollection = rules;

                    // Render each slide to SVG
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                        using (FileStream svgStream = File.Create(svgPath))
                        {
                            pres.Slides[i].WriteAsSvg(svgStream);
                        }
                    }

                    // Save the modified presentation
                    string savedPath = Path.Combine(outputFolder, "modified.pptx");
                    pres.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}