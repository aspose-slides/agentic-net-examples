using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string imagePath = "slide1.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Prepare font fallback rules collection
            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();
            rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            // Example rule for emoji fonts
            rules.Add(new FontFallBackRule(0x1F600, 0x1F64F, new string[] { "Segoe UI Emoji", "Apple Color Emoji" }));

            // Assign the prepared collection to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Render the first slide to an image
            IImage img = pres.Slides[0].GetImage(1f, 1f);
            img.Save(imagePath, Aspose.Slides.ImageFormat.Png);
            img.Dispose();

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}