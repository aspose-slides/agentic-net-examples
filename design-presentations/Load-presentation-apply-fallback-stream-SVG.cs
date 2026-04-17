using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create and assign font fallback rules
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the modified presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Stream the first slide as SVG to a file (simulating client stream)
            string svgPath = Path.Combine(Directory.GetCurrentDirectory(), "slide1.svg");
            using (FileStream svgStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
            {
                presentation.Slides[0].WriteAsSvg(svgStream);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}