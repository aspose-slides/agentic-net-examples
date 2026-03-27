using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCommentHeadings
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : Path.Combine(Environment.CurrentDirectory, "input.pptx");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            foreach (object authorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
                List<Aspose.Slides.IComment> commentsToRemove = new List<Aspose.Slides.IComment>();

                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                    commentsToRemove.Add(comment);
                }

                foreach (Aspose.Slides.IComment comment in commentsToRemove)
                {
                    comment.Remove();
                }
            }

            string outputPath = args.Length > 1 ? args[1] : Path.Combine(Environment.CurrentDirectory, "output.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}