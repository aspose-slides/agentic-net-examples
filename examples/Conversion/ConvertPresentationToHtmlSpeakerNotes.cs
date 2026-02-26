using System;

class Program
{
    static void Main()
    {
        // Input PowerPoint file
        string inputPath = "input.pptx";
        // Output HTML file with speaker notes
        string outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create HTML export options
        Aspose.Slides.Export.HtmlOptions htmlOpt = new Aspose.Slides.Export.HtmlOptions();

        // Configure notes layout to include speaker notes at the bottom
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

        // Apply notes layout options to HTML export
        htmlOpt.SlidesLayoutOptions = notesOptions;

        // Save the presentation as HTML with speaker notes
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

        // Release resources
        presentation.Dispose();
    }
}