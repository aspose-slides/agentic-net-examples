using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_with_comments.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
            // Ensure at least one slide exists
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        }

        // Add a second slide for demonstration
        presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("DevTeam", "DT");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

        // Add comments to slides
        author.Comments.AddComment("Review needed for this slide.", presentation.Slides[0], position, DateTime.Now);
        author.Comments.AddComment("Add more details here.", presentation.Slides[1], position, DateTime.Now);

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}