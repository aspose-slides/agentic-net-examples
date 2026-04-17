using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "sample.pptx";
        // Output HTML file path
        string outputPath = "output.html";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure HTML export options
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
            // Use a simple document formatter (no CSS, do not show slide titles)
            htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("", false);

            // Set notes layout to render notes below each slide
            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

            // Assign the notes layout to the HTML options
            htmlOptions.SlidesLayoutOptions = notesOptions;

            // Save the presentation as HTML with embedded notes
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Release resources
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Comment: format not supported
            Console.WriteLine("The specified file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}