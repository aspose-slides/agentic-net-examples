using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add an empty slide
        presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add comment authors
        Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author One", "A1");
        Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author Two", "A2");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);

        // Add a top-level comment
        Aspose.Slides.IComment comment1 = author1.Comments.AddComment("First comment", presentation.Slides[0], position, DateTime.Now);

        // Add replies to the top-level comment
        Aspose.Slides.IComment reply1 = author2.Comments.AddComment("Reply to first comment", presentation.Slides[0], position, DateTime.Now);
        reply1.ParentComment = comment1;

        Aspose.Slides.IComment reply2 = author2.Comments.AddComment("Second reply", presentation.Slides[0], position, DateTime.Now);
        reply2.ParentComment = comment1;

        // Add a sub-reply to the second reply
        Aspose.Slides.IComment subReply = author1.Comments.AddComment("Sub-reply to second reply", presentation.Slides[0], position, DateTime.Now);
        subReply.ParentComment = reply2;

        // Display comment hierarchy
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IComment[] allComments = slide.GetSlideComments(null);
        for (int i = 0; i < allComments.Length; i++)
        {
            Aspose.Slides.IComment current = allComments[i];
            while (current.ParentComment != null)
            {
                Console.Write("\t");
                current = current.ParentComment;
            }
            Console.Write("{0} : {1}", allComments[i].Author.Name, allComments[i].Text);
            Console.WriteLine();
        }

        // Save the presentation with comments
        string outputPath = "CommentsDemo.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Remove the top-level comment and its replies
        comment1.Remove();

        // Save the presentation after removal
        string outputPath2 = "CommentsDemo_Removed.pptx";
        presentation.Save(outputPath2, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}