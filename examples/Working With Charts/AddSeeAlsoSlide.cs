using System;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define the position for comments on the slide
        System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);

        // Add a root comment to the first slide
        Aspose.Slides.IComment rootComment = author.Comments.AddComment(
            "Root comment",
            presentation.Slides[0],
            position,
            DateTime.Now);

        // Add a child comment and link it to the root comment
        Aspose.Slides.IComment childComment = author.Comments.AddComment(
            "Child comment",
            presentation.Slides[0],
            position,
            DateTime.Now);
        childComment.ParentComment = rootComment;

        // Add a grand‑child comment and link it to the child comment
        Aspose.Slides.IComment grandChildComment = author.Comments.AddComment(
            "Grandchild comment",
            presentation.Slides[0],
            position,
            DateTime.Now);
        grandChildComment.ParentComment = childComment;

        // Save the presentation before exiting
        presentation.Save("ParentComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}