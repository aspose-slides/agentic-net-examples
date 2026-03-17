using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Collect all comment authors
                List<Aspose.Slides.ICommentAuthor> authors = new List<Aspose.Slides.ICommentAuthor>();
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    authors.Add(author);
                }

                // Remove comments and authors
                foreach (Aspose.Slides.ICommentAuthor author in authors)
                {
                    // Collect comments of the author
                    List<Aspose.Slides.IComment> comments = new List<Aspose.Slides.IComment>();
                    foreach (Aspose.Slides.IComment comment in author.Comments)
                    {
                        comments.Add(comment);
                    }

                    // Remove each comment
                    foreach (Aspose.Slides.IComment comment in comments)
                    {
                        comment.Remove();
                    }

                    // Remove the author from the collection
                    presentation.CommentAuthors.Remove(author);
                }

                // Save the cleaned presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}