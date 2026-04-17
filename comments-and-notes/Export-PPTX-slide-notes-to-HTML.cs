using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add an empty slide
        presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add comment authors
        Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A1");
        Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author_2", "A2");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(10f, 10f);

        // Add a root comment
        Aspose.Slides.IComment comment1 = author1.Comments.AddComment("Root comment", presentation.Slides[0], position, DateTime.Now);

        // Add first reply to the root comment
        Aspose.Slides.IComment reply1 = author2.Comments.AddComment("First reply to root", presentation.Slides[0], position, DateTime.Now);
        reply1.ParentComment = comment1;

        // Add second reply to the root comment
        Aspose.Slides.IComment reply2 = author2.Comments.AddComment("Second reply to root", presentation.Slides[0], position, DateTime.Now);
        reply2.ParentComment = comment1;

        // Add a sub-reply to the second reply
        Aspose.Slides.IComment subReply = author1.Comments.AddComment("Sub-reply to second reply", presentation.Slides[0], position, DateTime.Now);
        subReply.ParentComment = reply2;

        // Display the comment hierarchy
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
        for (int i = 0; i < comments.Length; i++)
        {
            Aspose.Slides.IComment current = comments[i];
            while (current.ParentComment != null)
            {
                Console.Write("\t");
                current = current.ParentComment;
            }
            Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
            Console.WriteLine();
        }

        // Save the presentation
        presentation.Save("ThreadedComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}