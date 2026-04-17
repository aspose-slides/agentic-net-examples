using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.html";
        string cssContent = "body { font-family: Arial; } .slide { border: 1px solid #000; }";
        string cssFileName = "branding.css";

        if (args.Length >= 2)
        {
            inputPath = args[0];
            outputPath = args[1];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            Html5Options htmlOptions = new Html5Options();
            htmlOptions.EmbedImages = true;

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = Directory.GetCurrentDirectory();
            }
            htmlOptions.OutputPath = outputDir;

            presentation.Save(outputPath, SaveFormat.Html5, htmlOptions);

            // Write custom CSS file to the output directory
            string cssFilePath = Path.Combine(outputDir, cssFileName);
            File.WriteAllText(cssFilePath, cssContent);

            // Insert CSS reference into the generated HTML
            string htmlContent = File.ReadAllText(outputPath);
            string cssLinkTag = $"<link rel=\"stylesheet\" type=\"text/css\" href=\"{cssFileName}\">";
            htmlContent = htmlContent.Replace("<head>", "<head>" + cssLinkTag);
            File.WriteAllText(outputPath, htmlContent);

            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}