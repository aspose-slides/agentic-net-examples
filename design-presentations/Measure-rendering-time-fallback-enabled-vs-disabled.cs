using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputWithoutFallback = "slide_without_fallback.png";
        string outputWithFallback = "slide_with_fallback.png";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Render without fallback fonts and measure time
            Stopwatch swWithout = Stopwatch.StartNew();
            Aspose.Slides.IImage imgWithout = pres.Slides[0].GetImage(1f, 1f);
            imgWithout.Save(outputWithoutFallback, Aspose.Slides.ImageFormat.Png);
            imgWithout.Dispose();
            swWithout.Stop();

            // Set fallback font rules
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Render with fallback fonts and measure time
            Stopwatch swWith = Stopwatch.StartNew();
            Aspose.Slides.IImage imgWith = pres.Slides[0].GetImage(1f, 1f);
            imgWith.Save(outputWithFallback, Aspose.Slides.ImageFormat.Png);
            imgWith.Dispose();
            swWith.Stop();

            // Output timing results
            Console.WriteLine("Rendering time without fallback: {0} ms", swWithout.ElapsedMilliseconds);
            Console.WriteLine("Rendering time with fallback: {0} ms", swWith.ElapsedMilliseconds);

            // Save presentation before exit
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}