// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add speaker note to title slide using C#

//

// Description:

// Demonstrates how to add a speaker notes slide to the title slide of a new

// presentation, populate it with bullet points (including a hyperlink) using

// Aspose.Slides for .NET, and save the result as a PPTX file. The example

// illustrates creating a presentation, accessing the first slide, adding a

// notes slide, editing the notes text frame, and handling save exceptions.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Speaker Note, Title Slide,

// NotesSlide, Bullet, Hyperlink, Presentation Processing, Office Automation

//

// Use Cases:

// - Programmatically add speaker notes with formatted bullet points to a slide.

// - Include clickable hyperlinks within speaker notes.

// - Automate generation of presentation templates with predefined notes.

// - Build .NET utilities for PowerPoint content enrichment and validation.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        var presentation = new Aspose.Slides.Presentation();



        // Get the title slide (first slide)

        var slide = presentation.Slides[0];



        // Add a notes slide to the title slide

        var notesManager = slide.NotesSlideManager;

        var notesSlide = notesManager.AddNotesSlide();



        // Get the notes text frame

        var notesTextFrame = notesSlide.NotesTextFrame;



        // Clear any existing paragraphs

        notesTextFrame.Paragraphs.Clear();



        // First bullet point with hyperlink

        var paragraph1 = new Aspose.Slides.Paragraph();

        paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;

        var portion1 = new Aspose.Slides.Portion();

        portion1.Text = "Visit Aspose website";

        portion1.PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.aspose.com");

        portion1.PortionFormat.HyperlinkClick.Tooltip = "Aspose Home";

        paragraph1.Portions.Add(portion1);

        notesTextFrame.Paragraphs.Add(paragraph1);



        // Second bullet point (plain text)

        var paragraph2 = new Aspose.Slides.Paragraph();

        paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;

        var portion2 = new Aspose.Slides.Portion();

        portion2.Text = "Remember to review the agenda";

        paragraph2.Portions.Add(portion2);

        notesTextFrame.Paragraphs.Add(paragraph2);



        // Save the presentation

        try

        {

            presentation.Save("SpeakerNotes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other save errors

            // Format not supported or other error: ex.Message

        }



        // Dispose the presentation

        presentation.Dispose();

    }

}

