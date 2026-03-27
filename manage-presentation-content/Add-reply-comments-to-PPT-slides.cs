using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation or create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        }

        // Add comment authors
        Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author1", "A1");
        Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author2", "A2");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(100, 100);

        // Add a main comment on the first slide
        Aspose.Slides.IComment comment1 = author1.Comments.AddComment("Main comment", presentation.Slides[0], position, DateTime.Now);

        // Add replies to the main comment
        Aspose.Slides.IComment reply1 = author2.Comments.AddComment("First reply", presentation.Slides[0], position, DateTime.Now);
        reply1.ParentComment = comment1;

        Aspose.Slides.IComment reply2 = author2.Comments.AddComment("Second reply", presentation.Slides[0], position, DateTime.Now);
        reply2.ParentComment = comment1;

        // Edit the text of the first reply
        reply1.Text = "Edited first reply";

        // Retrieve and display comment hierarchy
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
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}