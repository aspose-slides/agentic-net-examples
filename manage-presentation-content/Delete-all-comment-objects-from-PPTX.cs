using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_no_comments.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Remove all comments by clearing each author's comment collection
        foreach (object authorObj in presentation.CommentAuthors)
        {
            Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
            author.Comments.Clear();
        }

        // Save the presentation after removing comments
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();

        Console.WriteLine("All comments have been removed. Saved to: " + outputPath);
    }
}