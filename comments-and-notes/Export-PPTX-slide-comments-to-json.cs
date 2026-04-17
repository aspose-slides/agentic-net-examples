using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

class CommentInfo
{
    public int SlideNumber { get; set; }
    public string AuthorName { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; }
}

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "comments.json";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            List<CommentInfo> commentList = new List<CommentInfo>();

            foreach (object authorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                    if (comment.Slide != null && comment.Slide.Hidden)
                    {
                        CommentInfo info = new CommentInfo();
                        info.SlideNumber = comment.Slide.SlideNumber;
                        info.AuthorName = author.Name;
                        info.Text = comment.Text;
                        info.CreatedTime = comment.CreatedTime;
                        commentList.Add(info);
                    }
                }
            }

            string json = JsonSerializer.Serialize(commentList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(outputPath, json);

            // Save presentation before exit as required
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}