using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all comment authors
            foreach (object authorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.ICommentAuthor author = (Aspose.Slides.ICommentAuthor)authorObj;

                // Iterate through each comment of the author
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.IComment comment = (Aspose.Slides.IComment)commentObj;

                    // Remove the comment text
                    comment.Text = "";
                }
            }

            // Save the cleaned presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}