using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output paths
        var inputPath = "input.pptx";
        var outputHtml = "output.html";
        var zipPath = "output.zip";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (var pres = new Presentation(inputPath))
            {
                // Create temporary folder for HTML export
                var htmlFolder = Path.Combine(Path.GetDirectoryName(outputHtml), "html_output");
                if (!Directory.Exists(htmlFolder))
                    Directory.CreateDirectory(htmlFolder);

                // Export to HTML
                var htmlFilePath = Path.Combine(htmlFolder, Path.GetFileName(outputHtml));
                var htmlOptions = new HtmlOptions();
                pres.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

                // Bundle HTML and resources into a ZIP archive
                if (File.Exists(zipPath))
                    File.Delete(zipPath);
                ZipFile.CreateFromDirectory(htmlFolder, zipPath);

                // Clean up temporary folder
                Directory.Delete(htmlFolder, true);

                // Save presentation before exit
                pres.Save("saved.pptx", SaveFormat.Pptx);
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
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}