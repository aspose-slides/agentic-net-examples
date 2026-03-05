using System;
using System.Collections.Generic;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all comment authors in the presentation
        foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
        {
            // Collect comments to a separate list to avoid modifying the collection while iterating
            List<Aspose.Slides.IComment> commentsToRemove = new List<Aspose.Slides.IComment>();
            foreach (Aspose.Slides.IComment comment in author.Comments)
            {
                commentsToRemove.Add(comment);
            }

            // Remove each comment from the presentation
            foreach (Aspose.Slides.IComment comment in commentsToRemove)
            {
                comment.Remove();
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}