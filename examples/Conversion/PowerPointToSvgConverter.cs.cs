using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file path (default: input.pptx)
        string inputPath = "input.pptx";
        // Output folder for SVG files and saved presentation (default: output)
        string outputFolder = "output";

        // Override defaults with command‑line arguments if provided
        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputFolder = args[1];
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputFolder);

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Save the presentation before exiting (as required by the rules)
            string savedPptxPath = Path.Combine(outputFolder, "saved.pptx");
            pres.Save(savedPptxPath, SaveFormat.Pptx);

            // Convert each slide to an individual SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                string svgFilePath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                using (FileStream svgStream = new FileStream(svgFilePath, FileMode.Create))
                {
                    // Write the slide as SVG to the file stream
                    pres.Slides[i].WriteAsSvg(svgStream);
                }
            }
        }
    }
}