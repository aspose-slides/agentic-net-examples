using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputSvgDir = "output_svg";
            string outputPresPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                // Input file does not exist
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Create fallback rule for Arabic Unicode range (0x0600-0x06FF) using an Arabic OpenType font
                IFontFallBackRule arabicRule = new FontFallBackRule(0x0600u, 0x06FFu, "Amiri");
                // Add rule to collection
                IFontFallBackRulesCollection rules = pres.FontsManager.FontFallBackRulesCollection;
                rules.Add(arabicRule);
                pres.FontsManager.FontFallBackRulesCollection = rules;

                // Ensure output directory exists
                if (!Directory.Exists(outputSvgDir))
                {
                    Directory.CreateDirectory(outputSvgDir);
                }

                // Export each slide as SVG
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    string svgPath = Path.Combine(outputSvgDir, $"slide_{i + 1}.svg");
                    using (FileStream fs = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                    {
                        pres.Slides[i].WriteAsSvg(fs);
                    }
                }

                // Save presentation before exit
                pres.Save(outputPresPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                // Format not supported
            }
        }
    }
}