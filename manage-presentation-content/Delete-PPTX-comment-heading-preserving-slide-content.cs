using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsByHeading
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";
                string heading = "HeadingToRemove";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<IComment> commentsToRemove = new List<IComment>();

                    foreach (ICommentAuthor author in presentation.CommentAuthors)
                    {
                        foreach (IComment comment in author.Comments)
                        {
                            if (comment.Text != null && comment.Text.StartsWith(heading))
                            {
                                commentsToRemove.Add(comment);
                            }
                        }
                    }

                    foreach (IComment comment in commentsToRemove)
                    {
                        comment.Remove();
                    }

                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}