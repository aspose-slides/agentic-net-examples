using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
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
        }

        // Add a modern comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Contemporary Author", "CA");

        // Add a modern comment to the first slide
        Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
            "This is a modern comment",
            presentation.Slides[0],
            null,
            new System.Drawing.PointF(100, 100),
            System.DateTime.Now);

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}