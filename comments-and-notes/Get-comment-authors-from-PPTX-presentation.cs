using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)
                {
                    Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)commentAuthor;
                    foreach (Aspose.Slides.IComment comment in author.Comments)
                    {
                        Aspose.Slides.Comment c = (Aspose.Slides.Comment)comment;
                        Console.WriteLine("Author: {0} ({1}) - Slide: {2} - Text: {3}",
                            author.Name, author.Initials, c.Slide.SlideNumber, c.Text);
                    }
                }

                // Save the presentation (no modifications) to satisfy save-before-exit rule
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}