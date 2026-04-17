using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");
            string commentText = "This is a sample comment.";

            // Validate that comment text does not contain prohibited characters
            char[] prohibitedChars = new char[] { '@', '#', '$' };
            bool containsProhibited = false;
            foreach (char c in prohibitedChars)
            {
                if (commentText.IndexOf(c) >= 0)
                {
                    containsProhibited = true;
                    break;
                }
            }

            if (containsProhibited)
            {
                Console.WriteLine("Comment contains prohibited characters. Skipping save.");
            }
            else
            {
                Aspose.Slides.IModernComment comment = author.Comments.AddModernComment(
                    commentText,
                    presentation.Slides[0],
                    null,
                    new System.Drawing.PointF(100f, 100f),
                    DateTime.Now);

                presentation.Save(outputPath, SaveFormat.Pptx);
            }

            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}