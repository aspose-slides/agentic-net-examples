using System;
using System.IO;
using System.Text;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = "input.pptx";
        string outputPath = "output.md";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Prepare Markdown save options
            Aspose.Slides.Export.MarkdownSaveOptions mdOptions = new Aspose.Slides.Export.MarkdownSaveOptions();
            mdOptions.ShowSlideNumber = true;
            mdOptions.SlideNumberFormat = "# Slide {0}";
            mdOptions.ExportType = Aspose.Slides.Export.MarkdownExportType.Visual;

            // Save presentation to Markdown
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Md, mdOptions);

            // Generate Table of Contents
            int slideCount = presentation.Slides.Count;
            StringBuilder tocBuilder = new StringBuilder();
            tocBuilder.AppendLine("# Table of Contents");
            for (int i = 1; i <= slideCount; i++)
            {
                tocBuilder.AppendLine("- [Slide " + i + "](#slide-" + i + ")");
            }
            string toc = tocBuilder.ToString();

            // Read generated Markdown, prepend TOC, and write back
            string markdownContent = File.ReadAllText(outputPath);
            string finalContent = toc + Environment.NewLine + markdownContent;
            File.WriteAllText(outputPath, finalContent);

            // Save presentation before exit (optional, preserves original)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}