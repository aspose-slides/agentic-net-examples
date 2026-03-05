using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Presentation presentation = new Presentation("input.pptx");

        // Remove all comments by clearing each author's comment collection
        foreach (ICommentAuthor author in presentation.CommentAuthors)
        {
            author.Comments.Clear();
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}