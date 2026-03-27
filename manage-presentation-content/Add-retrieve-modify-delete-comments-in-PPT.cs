using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // File paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
            // Add an empty slide to the new presentation
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        }

        // Add comment authors
        Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author1", "A1");
        Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author2", "A2");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(100, 100);

        // Add comments to the first slide
        Aspose.Slides.IComment comment1 = author1.Comments.AddComment("First comment", presentation.Slides[0], position, DateTime.Now);
        Aspose.Slides.IComment comment2 = author2.Comments.AddComment("Second comment", presentation.Slides[0], position, DateTime.Now);

        // Add a reply to the first comment
        Aspose.Slides.IComment reply1 = author2.Comments.AddComment("Reply to first comment", presentation.Slides[0], position, DateTime.Now);
        reply1.ParentComment = comment1;

        // Retrieve and display comments hierarchy from the slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IComment[] slideComments = slide.GetSlideComments(null);
        for (int i = 0; i < slideComments.Length; i++)
        {
            Aspose.Slides.IComment c = slideComments[i];
            Aspose.Slides.IComment temp = c;
            while (temp.ParentComment != null)
            {
                Console.Write("\t");
                temp = temp.ParentComment;
            }
            Console.WriteLine("{0}: {1}", c.Author.Name, c.Text);
        }

        // Modify the text of the second comment
        comment2.Text = "Modified second comment";

        // Delete the first comment along with its replies
        comment1.Remove();

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}