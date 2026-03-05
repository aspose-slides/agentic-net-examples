using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Create a collection for font fallback rules
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

        // Add a fallback rule for Unicode range 0x400-0x4FF using Times New Roman
        rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

        // Assign the fallback rules to the presentation's FontsManager
        pres.FontsManager.FontFallBackRulesCollection = rules;

        // Render the first slide to an image with default scaling
        Aspose.Slides.IImage img = pres.Slides[0].GetImage(1f, 1f);

        // Save the rendered slide as a PNG file
        img.Save("slide.png", Aspose.Slides.ImageFormat.Png);
        img.Dispose();

        // Save the presentation before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}