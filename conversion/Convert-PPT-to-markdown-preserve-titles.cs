using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputFolder = "Input";
        string outputFolder = "Output";
        string presentationFile = "sample.pptx";
        string markdownFileName = "sample.md";

        string inputPath = Path.Combine(inputFolder, presentationFile);
        string outputPath = Path.Combine(outputFolder, markdownFileName);

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.MarkdownSaveOptions mdOptions = new Aspose.Slides.Export.MarkdownSaveOptions();
            mdOptions.ShowHiddenSlides = true;
            mdOptions.ShowSlideNumber = true;
            mdOptions.Flavor = Aspose.Slides.Export.Flavor.Github;
            mdOptions.ExportType = Aspose.Slides.Export.MarkdownExportType.Sequential;
            mdOptions.NewLineType = Aspose.Slides.Export.NewLineType.Unix;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Md, mdOptions);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}