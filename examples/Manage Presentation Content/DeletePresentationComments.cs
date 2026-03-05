using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing PPTX presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Iterate through all comment authors in the presentation
            foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)
            {
                // Iterate through each comment belonging to the current author
                foreach (Aspose.Slides.IComment comment in commentAuthor.Comments)
                {
                    // Identify comments that need to be deleted (e.g., containing specific text)
                    if (comment.Text != null && comment.Text.Contains("DeleteMe"))
                    {
                        // Remove the comment and all its replies from the slide
                        comment.Remove();
                    }
                }
            }

            // Save the modified presentation before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}