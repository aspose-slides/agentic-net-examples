using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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
            foreach (object authorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                    Console.WriteLine("Author: " + author.Name);
                    Console.WriteLine("Comment: " + comment.Text);
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}