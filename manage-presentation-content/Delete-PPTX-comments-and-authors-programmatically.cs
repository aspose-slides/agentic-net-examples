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
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Presentation(inputPath))
            {
                // Collect all comment authors
                var authors = new List<ICommentAuthor>();
                foreach (var author in presentation.CommentAuthors)
                {
                    authors.Add(author);
                }

                // Remove comments and authors
                foreach (var author in authors)
                {
                    var comments = author.Comments;
                    while (comments.Count > 0)
                    {
                        var comment = comments[0];
                        comment.Remove();
                    }

                    presentation.CommentAuthors.Remove(author);
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}