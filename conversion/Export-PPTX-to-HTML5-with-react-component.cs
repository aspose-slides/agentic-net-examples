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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            Html5Options html5Options = new Html5Options();
            html5Options.AnimateShapes = true;
            html5Options.AnimateTransitions = true;
            // html5Options.OutputPath = "resources"; // optional: set folder for external resources

            presentation.Save(outputPath, SaveFormat.Html5, html5Options);
            presentation.Dispose();

            Console.WriteLine("Presentation exported to HTML5 successfully: " + outputPath);
            // The generated HTML file can be loaded into a React component for dynamic rendering.
        }
        catch (Exception ex)
        {
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}