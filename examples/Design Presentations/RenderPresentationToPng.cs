using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DesignPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file
            string inputPath = "input.pptx";
            // Output directory for PNG images
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Create fallback font rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
            // Example fallback rule for Unicode range 0x400-0x4FF using Times New Roman
            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            // Additional fallback rule for emoji fonts (example)
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji", "Noto Color Emoji" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            // Apply the fallback rules to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Render each slide to a PNG image
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.IImage img = pres.Slides[i].GetImage(1f, 1f);
                string outputPath = Path.Combine(outputDir, $"slide_{i}.png");
                img.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                img.Dispose();
            }

            // Save the presentation (required by authoring rules)
            string savedPresentationPath = Path.Combine(outputDir, "presentation_saved.pptx");
            pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}