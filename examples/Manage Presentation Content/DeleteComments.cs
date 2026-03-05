using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Presentation presentation = new Presentation("input.pptx");

        // Text of the comment to be removed
        string targetCommentText = "Topic to delete";

        // Iterate over all comment authors in the presentation
        foreach (ICommentAuthor author in presentation.CommentAuthors)
        {
            // Iterate backwards through the author's comments to safely remove items
            for (int i = author.Comments.Count - 1; i >= 0; i--)
            {
                IComment comment = author.Comments[i];
                if (comment.Text == targetCommentText)
                {
                    // Remove the comment (and its replies) from the collection
                    comment.Remove();
                }
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}