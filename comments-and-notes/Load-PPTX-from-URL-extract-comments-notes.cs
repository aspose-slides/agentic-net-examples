// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX from URL extract comments notes using C#

//

// Description:

// Demonstrates how to download a PPTX file from a URL, load it with Aspose.Slides,

// and extract both slide comments and slide notes using C#. The example shows the

// required presentation‑processing steps for PowerPoint files and produces the

// requested output in a standalone console application. Developers can use this

// pattern to automate PPTX workflows, validate results, or integrate presentation

// logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, URL, Extract, Comments, Notes,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading a PPTX from a remote URL and extracting comments and notes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation content before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Net.Http;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // URL of the presentation

        string url = "https://example.com/sample.pptx";



        // Download presentation into a stream

        HttpClient httpClient = new HttpClient();

        Stream presentationStream = null;

        try

        {

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            response.EnsureSuccessStatusCode();

            presentationStream = response.Content.ReadAsStreamAsync().Result;

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error downloading presentation: " + ex.Message);

            return;

        }



        // Load presentation from the stream

        Aspose.Slides.Presentation presentation = null;

        try

        {

            presentation = new Aspose.Slides.Presentation(presentationStream);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error loading presentation: " + ex.Message);

            return;

        }



        // Extract and display comments

        foreach (object authorObj in presentation.CommentAuthors)

        {

            Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;

            foreach (object commentObj in author.Comments)

            {

                Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;

                Console.WriteLine("Slide " + comment.Slide.SlideNumber + " Comment: " + comment.Text + " Author: " + comment.Author.Name);

            }

        }



        // Extract and display notes for each slide

        for (int i = 0; i < presentation.Slides.Count; i++)

        {

            Aspose.Slides.ISlide slide = presentation.Slides[i];

            Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;

            Aspose.Slides.INotesSlide notesSlide = notesMgr.NotesSlide;

            if (notesSlide != null && notesSlide.NotesTextFrame != null)

            {

                string notesText = notesSlide.NotesTextFrame.Text;

                Console.WriteLine("Slide " + slide.SlideNumber + " Notes: " + notesText);

            }

        }



        // Save presentation to a memory stream before exiting

        using (MemoryStream memoryStream = new MemoryStream())

        {

            presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx);

        }



        // Clean up resources

        presentation.Dispose();

        httpClient.Dispose();

        if (presentationStream != null) presentationStream.Dispose();

    }

}

