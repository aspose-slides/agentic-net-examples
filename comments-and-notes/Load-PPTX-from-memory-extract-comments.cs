using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation file path
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation from a memory stream
            byte[] fileData = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(fileData))
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputStream);

                // Access and display comments
                foreach (object authorObj in presentation.CommentAuthors)
                {
                    Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
                    foreach (object commentObj in author.Comments)
                    {
                        Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                        Console.WriteLine("Slide " + comment.Slide.SlideNumber + ": " + comment.Text + " (Author: " + author.Name + ")");
                    }
                }

                // Save the presentation to a memory stream (no disk write)
                using (MemoryStream outputStream = new MemoryStream())
                {
                    presentation.Save(outputStream, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                presentation.Dispose();
            }
        }
        catch (Exception ex) when (ex.Message.Contains("format"))
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