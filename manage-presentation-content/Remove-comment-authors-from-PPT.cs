using System;
using System.Collections.Generic;
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
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Remove all comments from each slide
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                IComment[] slideComments = slide.GetSlideComments(null);
                for (int commentIndex = 0; commentIndex < slideComments.Length; commentIndex++)
                {
                    slideComments[commentIndex].Remove();
                }
            }

            // Collect all comment authors before removal
            List<ICommentAuthor> authors = new List<ICommentAuthor>();
            foreach (object authorObj in presentation.CommentAuthors)
            {
                CommentAuthor author = (CommentAuthor)authorObj;
                authors.Add(author);
            }

            // Remove each author
            foreach (ICommentAuthor author in authors)
            {
                author.Remove();
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}