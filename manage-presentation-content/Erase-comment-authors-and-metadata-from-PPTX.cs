using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
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

            // Iterate through all comment authors
            foreach (object authorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;

                // Gather comments to remove (to avoid modifying collection during iteration)
                System.Collections.Generic.List<Aspose.Slides.IComment> commentsToRemove = new System.Collections.Generic.List<Aspose.Slides.IComment>();
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.IComment comment = (Aspose.Slides.IComment)commentObj;
                    commentsToRemove.Add(comment);
                }

                // Remove each comment
                foreach (Aspose.Slides.IComment comment in commentsToRemove)
                {
                    comment.Remove();
                }

                // Remove the author from the collection
                author.Remove();
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("All comments and authors have been removed. Saved to: " + outputPath);
        }
    }
}