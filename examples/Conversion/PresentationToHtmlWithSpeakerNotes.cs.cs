using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set up HTML5 export options
        Aspose.Slides.Export.Html5Options html5Options = new Aspose.Slides.Export.Html5Options();
        html5Options.OutputPath = System.IO.Path.GetDirectoryName(outputPath);

        // Configure notes layout to appear at the bottom
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

        // Apply notes layout options to the HTML5 export
        html5Options.SlidesLayoutOptions = notesOptions;

        // Save the presentation as HTML5 with speaker notes
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, html5Options);

        // Clean up resources
        presentation.Dispose();
    }
}