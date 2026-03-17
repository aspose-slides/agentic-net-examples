using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_no_comments.pptx";

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ICommentAuthorCollection authors = presentation.CommentAuthors;

                    for (int authorIndex = authors.Count - 1; authorIndex >= 0; authorIndex--)
                    {
                        Aspose.Slides.ICommentAuthor author = authors[authorIndex];
                        Aspose.Slides.ICommentCollection comments = author.Comments;

                        while (comments.Count > 0)
                        {
                            Aspose.Slides.IComment comment = comments[0];
                            comment.Remove();
                        }

                        authors.Remove(author);
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}