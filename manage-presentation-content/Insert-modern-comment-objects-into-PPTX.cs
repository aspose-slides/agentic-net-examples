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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define the position for the modern comment
        System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);

        // Insert a modern comment on the first slide
        Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
            "This is a modern comment.",
            presentation.Slides[0],
            null,
            position,
            DateTime.Now);

        // Save the presentation with the new comment
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}