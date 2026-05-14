using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        var dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        var inputPath = Path.Combine(dataDir, "input.pptx");
        var outputPath = Path.Combine(dataDir, "output.pptx");

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get a layout slide (first one for demonstration)
                var layoutSlide = presentation.Masters[0].LayoutSlides[0];

                // Set footer visibility to true on the layout slide (affects its child placeholders)
                var layoutHeaderFooter = layoutSlide.HeaderFooterManager;
                layoutHeaderFooter.SetFooterAndChildFootersVisibility(true);

                // Hide footers on child slides that use this layout
                foreach (var slide in presentation.Slides)
                {
                    if (slide.LayoutSlide == layoutSlide)
                    {
                        var slideHeaderFooter = slide.HeaderFooterManager;
                        slideHeaderFooter.SetFooterVisibility(false);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}