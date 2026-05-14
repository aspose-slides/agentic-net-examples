using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.pptx";

        try
        {
            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Iterate through each layout slide in the selected master slide
            foreach (Aspose.Slides.ILayoutSlide layoutSlide in masterSlide.LayoutSlides)
            {
                // Add a text placeholder to the layout slide
                Aspose.Slides.IAutoShape placeholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(20, 20, 500, 300);
                // Optionally add default text to the placeholder
                placeholder.AddTextFrame("Placeholder");
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}