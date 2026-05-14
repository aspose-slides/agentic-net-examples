using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportComments
{
    class Program
    {
        static void Main(string[] args)
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<CommentInfo> allComments = new List<CommentInfo>();

                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IComment[] comments = slide.GetSlideComments(null);
                        foreach (IComment comment in comments)
                        {
                            CommentInfo info = new CommentInfo();
                            info.SlideNumber = i + 1;
                            info.AuthorName = comment.Author.Name;
                            info.AuthorInitials = comment.Author.Initials;
                            info.Text = comment.Text;
                            info.CreatedTime = comment.CreatedTime;
                            allComments.Add(info);
                        }
                    }

                    string json = JsonSerializer.Serialize(allComments, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(outputPath, json);

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    public class CommentInfo
    {
        public int SlideNumber { get; set; }
        public string AuthorName { get; set; }
        public string AuthorInitials { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}