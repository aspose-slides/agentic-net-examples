using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputSerif = "slide_serif.png";
        string outputSans = "slide_sans.png";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load with serif default font
            LoadOptions loadSerif = new LoadOptions();
            loadSerif.DefaultRegularFont = "Times New Roman";
            using (Presentation presSerif = new Presentation(inputPath, loadSerif))
            {
                IRenderingOptions renderSerif = new RenderingOptions();
                renderSerif.DefaultRegularFont = "Times New Roman";

                IImage imgSerif = presSerif.Slides[0].GetImage(renderSerif);
                imgSerif.Save(outputSerif, Aspose.Slides.ImageFormat.Png);

                // Save presentation (no modifications)
                presSerif.Save("output_serif.pptx", SaveFormat.Pptx);
            }

            // Load with sans‑serif default font
            LoadOptions loadSans = new LoadOptions();
            loadSans.DefaultRegularFont = "Arial";
            using (Presentation presSans = new Presentation(inputPath, loadSans))
            {
                IRenderingOptions renderSans = new RenderingOptions();
                renderSans.DefaultRegularFont = "Arial";

                IImage imgSans = presSans.Slides[0].GetImage(renderSans);
                imgSans.Save(outputSans, Aspose.Slides.ImageFormat.Png);

                // Save presentation (no modifications)
                presSans.Save("output_sans.pptx", SaveFormat.Pptx);
            }
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