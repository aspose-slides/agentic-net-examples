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