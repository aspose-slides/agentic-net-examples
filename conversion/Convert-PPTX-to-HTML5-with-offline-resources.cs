using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.html";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure HTML5 export options to embed all resources locally
            Aspose.Slides.Export.Html5Options html5Options = new Aspose.Slides.Export.Html5Options();
            html5Options.EmbedImages = true;                     // Embed images
            html5Options.OutputPath = Path.GetDirectoryName(outputPath); // Store resources in the same folder as output

            // Save as HTML5
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, html5Options);

            // Dispose the presentation
            presentation.Dispose();
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