// -----------------------------------------------------------------------------
// Example: Export PPTX slide notes to HTML using C#
//
// Description:
// Demonstrates how to export PPTX slide notes to HTML using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a slide with
// notes, and saves only the notes as an HTML file in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// extract slide notes for documentation, or integrate presentation logic into
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Pptx, Slide, 
// Notes, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of PPTX slide notes to HTML.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Extract slide notes for documentation or reporting purposes.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Access the first slide (automatically added)
            ISlide slide = presentation.Slides[0];

            // Add notes to the slide
            INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
            notesSlide.TextFrame.Text = "These are the notes for the first slide.\nThey can contain multiple lines of text.";

            // Configure HTML export options to include only notes
            HtmlOptions htmlOptions = new HtmlOptions
            {
                NotesCommentsLayout = NotesCommentsLayoutType.NotesOnly
            };

            // Save only the notes as an HTML file
            presentation.Save("SlideNotes.html", SaveFormat.Html, htmlOptions);
        }
    }
}
