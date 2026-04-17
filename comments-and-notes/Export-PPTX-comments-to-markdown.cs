using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "Comments1.pptx";
            string outputPath = "Comments.md";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (ICommentAuthor author in pres.CommentAuthors)
                    {
                        foreach (IComment comment in author.Comments)
                        {
                            writer.WriteLine("> " + comment.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing markdown file: " + ex.Message);
            }

            // Save presentation before exit
            try
            {
                pres.Save(inputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            pres.Dispose();
        }
    }
}