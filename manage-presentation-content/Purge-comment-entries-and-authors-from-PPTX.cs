using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = new Presentation(inputPath);

            // Remove all comments from each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                IComment[] comments = slide.GetSlideComments(null);
                for (int j = 0; j < comments.Length; j++)
                {
                    comments[j].Remove();
                }
            }

            // Collect all comment authors
            List<ICommentAuthor> authors = new List<ICommentAuthor>();
            foreach (object obj in presentation.CommentAuthors)
            {
                ICommentAuthor author = (ICommentAuthor)obj;
                authors.Add(author);
            }

            // Remove each author
            foreach (ICommentAuthor author in authors)
            {
                author.Remove();
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}