using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file and output HTML file paths
        string inputPath = "example.pptx";
        string outputPath = "output.html";
        string cssPath = "styles.css";

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

            // Configure HTML export options with external CSS
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(cssPath, true);

            // Export the presentation to HTML
            presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation exported successfully.");
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error during export: " + ex.Message);
        }
    }
}