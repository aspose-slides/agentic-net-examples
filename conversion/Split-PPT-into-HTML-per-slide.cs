using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create output directory for HTML files
                string outputDir = Path.Combine(Environment.CurrentDirectory, "HtmlSlides");
                if (!Directory.Exists(outputDir))
                    Directory.CreateDirectory(outputDir);

                // Iterate through each slide and save it as a separate HTML file
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    int[] slideIndex = new int[] { i + 1 }; // Slides are 1‑based for the Save method
                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.html");
                    presentation.Save(outputPath, slideIndex, SaveFormat.Html5);
                }

                // Save the original presentation before exiting (unchanged)
                string savedPath = Path.Combine(outputDir, "original_saved.pptx");
                presentation.Save(savedPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}