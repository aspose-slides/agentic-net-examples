using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the presentation file.");
            return;
        }

        string inputPath = args[0];
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // List all comments
            foreach (object authorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                    Console.WriteLine("Slide " + comment.Slide.SlideNumber + " Comment: " + comment.Text + " Author: " + author.Name + " Time: " + comment.CreatedTime);
                }
            }

            // List notes for each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
                if (notesMgr != null && notesMgr.NotesSlide != null && notesMgr.NotesSlide.NotesTextFrame != null)
                {
                    string notesText = notesMgr.NotesSlide.NotesTextFrame.Text;
                    Console.WriteLine("Slide " + slide.SlideNumber + " Notes: " + notesText);
                }
                else
                {
                    Console.WriteLine("Slide " + slide.SlideNumber + " has no notes.");
                }
            }

            // Save presentation before exit
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + "_out.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // If the format is not supported, comment that format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported
        }
    }
}