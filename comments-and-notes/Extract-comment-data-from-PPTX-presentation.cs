using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    List<CommentInfo> allComments = new List<CommentInfo>();

                    foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                    {
                        Aspose.Slides.ICommentCollection authorComments = author.Comments;
                        foreach (Aspose.Slides.IComment comment in authorComments)
                        {
                            CommentInfo info = new CommentInfo();
                            info.SlideNumber = comment.Slide.SlideNumber;
                            info.AuthorName = comment.Author.Name;
                            info.Text = comment.Text;
                            info.CreatedTime = comment.CreatedTime;
                            allComments.Add(info);
                        }
                    }

                    foreach (CommentInfo info in allComments)
                    {
                        Console.WriteLine("Slide " + info.SlideNumber + ": [" + info.AuthorName + "] " + info.Text + " (" + info.CreatedTime + ")");
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class CommentInfo
    {
        public int SlideNumber { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}