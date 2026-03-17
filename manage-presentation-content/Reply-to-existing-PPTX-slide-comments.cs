using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCommentReply
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Ensure there is at least one comment author and one comment
                    if (presentation.CommentAuthors.Count > 0 && presentation.CommentAuthors[0].Comments.Count > 0)
                    {
                        // Get the first existing comment to reply to
                        IComment originalComment = presentation.CommentAuthors[0].Comments[0];

                        // Add a new author for the reply (could be the same author as well)
                        ICommentAuthor replyAuthor = presentation.CommentAuthors.AddAuthor("Reply Author", "RA");

                        // Define position for the reply comment
                        PointF replyPosition = new PointF(0.5f, 0.5f);

                        // Add a modern comment as the reply
                        IModernComment replyComment = replyAuthor.Comments.AddModernComment(
                            "This is a reply to the original comment",
                            originalComment.Slide,
                            null,
                            replyPosition,
                            DateTime.Now);

                        // Link the reply to the original comment
                        replyComment.ParentComment = originalComment;
                    }

                    // Save the updated presentation in PPTX format
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}