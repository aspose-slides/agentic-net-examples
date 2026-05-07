using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
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
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Export each slide to a separate HTML file
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.html");
                    int[] slideIndices = new int[] { i + 1 };
                    presentation.Save(outputPath, slideIndices, SaveFormat.Html);
                }

                // Save the original presentation before exiting
                string savedPresPath = Path.Combine(outputDir, "original_saved.pptx");
                presentation.Save(savedPresPath, SaveFormat.Pptx);
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