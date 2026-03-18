using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input PPTX and output HTML
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Set HTML export options (optional)
            HtmlOptions htmlOptions = new HtmlOptions();

            // Export the presentation to a single HTML file
            presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Save the presentation (as PPTX) before exiting, as required
            presentation.Save("temp_saved.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}