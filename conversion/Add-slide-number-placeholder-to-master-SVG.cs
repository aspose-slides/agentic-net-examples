using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output paths
        string inputPath = "input.pptx";
        string outputDirectory = "output";
        string savedPresentationPath = Path.Combine(outputDirectory, "presentation_with_numbers.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Make slide number placeholder visible on the master slide
            Aspose.Slides.IMasterSlideHeaderFooterManager masterHeaderFooter = presentation.Masters[0].HeaderFooterManager;
            masterHeaderFooter.SetSlideNumberAndChildSlideNumbersVisibility(true);

            // Save the modified presentation (PPTX)
            presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Export each slide to SVG
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                string svgPath = Path.Combine(outputDirectory, $"slide_{i + 1}.svg");
                using (FileStream svgStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                {
                    presentation.Slides[i].WriteAsSvg(svgStream);
                }
            }

            // Clean up
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}