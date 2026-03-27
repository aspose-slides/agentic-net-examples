using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsApp
{
    class Program
    {
        static void Main(string[] args)
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

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Collect all comment authors
            List<ICommentAuthor> authors = new List<ICommentAuthor>();
            foreach (object authorObj in presentation.CommentAuthors)
            {
                ICommentAuthor author = (ICommentAuthor)authorObj;
                authors.Add(author);
            }

            // Remove all comments and their authors
            foreach (ICommentAuthor author in authors)
            {
                // Collect comments for the current author
                List<IComment> comments = new List<IComment>();
                foreach (object commentObj in author.Comments)
                {
                    IComment comment = (IComment)commentObj;
                    comments.Add(comment);
                }

                // Remove each comment
                foreach (IComment comment in comments)
                {
                    comment.Remove();
                }

                // Remove the author
                author.Remove();
            }

            // Save the cleaned presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}