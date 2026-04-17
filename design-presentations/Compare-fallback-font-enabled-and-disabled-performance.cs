using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "large.pptx";
        string outputEnabled = "render_enabled.png";
        string outputDisabled = "render_disabled.png";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Enable fallback fonts
            Aspose.Slides.IFontFallBackRulesCollection rulesEnabled = new Aspose.Slides.FontFallBackRulesCollection();
            rulesEnabled.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            pres.FontsManager.FontFallBackRulesCollection = rulesEnabled;

            // Render with fallback enabled
            Stopwatch swEnabled = new Stopwatch();
            swEnabled.Start();
            Aspose.Slides.IImage imgEnabled = pres.Slides[0].GetImage(1f, 1f);
            swEnabled.Stop();
            imgEnabled.Save(outputEnabled, Aspose.Slides.ImageFormat.Png);
            imgEnabled.Dispose();

            // Disable fallback fonts (empty collection)
            Aspose.Slides.IFontFallBackRulesCollection rulesDisabled = new Aspose.Slides.FontFallBackRulesCollection();
            pres.FontsManager.FontFallBackRulesCollection = rulesDisabled;

            // Render with fallback disabled
            Stopwatch swDisabled = new Stopwatch();
            swDisabled.Start();
            Aspose.Slides.IImage imgDisabled = pres.Slides[0].GetImage(1f, 1f);
            swDisabled.Stop();
            imgDisabled.Save(outputDisabled, Aspose.Slides.ImageFormat.Png);
            imgDisabled.Dispose();

            Console.WriteLine($"Rendering with fallback enabled: {swEnabled.ElapsedMilliseconds} ms");
            Console.WriteLine($"Rendering with fallback disabled: {swDisabled.ElapsedMilliseconds} ms");

            // Save presentation before exit
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}