using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing PPTX file
        Presentation presentation = new Presentation("input.pptx");

        // Iterate through each comment author in the presentation
        foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
        {
            // Collect comments to a temporary list to avoid modifying the collection during iteration
            List<IComment> commentsToRemove = new List<IComment>();
            foreach (IComment comment in commentAuthor.Comments)
            {
                commentsToRemove.Add(comment);
            }

            // Remove each comment (and its replies) from the presentation
            foreach (IComment comment in commentsToRemove)
            {
                comment.Remove();
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}