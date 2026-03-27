using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation – starting point for adding collaborative comments
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a comment author – identifies who is providing feedback
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define the position on the slide where the comment will appear
        System.Drawing.PointF position = new System.Drawing.PointF(100f, 150f);

        // Add a modern comment to the first slide.
        // Modern comments support richer metadata and are ideal for revision tracking.
        Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
            "This slide needs review for data accuracy.",
            presentation.Slides[0],
            null,
            position,
            System.DateTime.Now);

        // Save the presentation with the added comments.
        // Saving ensures that collaborators can see the feedback in the PPTX file.
        presentation.Save("CollaborationComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}