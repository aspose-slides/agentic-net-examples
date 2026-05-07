using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output HTML file path
        string outputPath = "output.html";
        // URL of external CSS file
        string cssUrl = "styles.css";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Set up HTML export options with external CSS
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(cssUrl, false);

            // Export to HTML
            presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}