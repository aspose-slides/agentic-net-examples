using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPathPattern = "slide_{0}.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create HTML export options
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

        // Use a custom HTML formatting controller (empty implementation)
        htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // Configure notes layout options (optional)
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        htmlOptions.SlidesLayoutOptions = notesOptions; // ISlidesLayoutOptions implementation

        // Export each slide individually to HTML
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            string outputPath = string.Format(outputPathPattern, i + 1);
            presentation.Save(outputPath, new int[] { i + 1 }, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
        }

        // Save the presentation before exiting (as per authoring rule)
        presentation.Save("final_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}

// Minimal custom formatting controller implementing IHtmlFormattingController
class CustomFormattingController : Aspose.Slides.Export.IHtmlFormattingController
{
    public void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation) { }
    public void WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation) { }
    public void WriteSlideStart(IHtmlGenerator generator, ISlide slide) { }
    public void WriteSlideEnd(IHtmlGenerator generator, ISlide slide) { }
    public void WriteShapeStart(IHtmlGenerator generator, IShape shape) { }
    public void WriteShapeEnd(IHtmlGenerator generator, IShape shape) { }
}