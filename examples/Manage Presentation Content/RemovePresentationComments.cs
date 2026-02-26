using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing PPT presentation
        Presentation presentation = new Presentation("input.pptx");

        // Iterate through all comment authors in the presentation
        foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
        {
            // Store comments to be removed to avoid modifying the collection during iteration
            List<IComment> commentsToRemove = new List<IComment>();
            foreach (IComment comment in commentAuthor.Comments)
            {
                commentsToRemove.Add(comment);
            }

            // Remove each comment from the presentation
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