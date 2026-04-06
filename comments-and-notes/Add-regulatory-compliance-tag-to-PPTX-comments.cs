using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all comment authors
                foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)
                {
                    // Iterate through each comment of the author
                    foreach (Aspose.Slides.IComment comment in commentAuthor.Comments)
                    {
                        // Append a regulatory compliance tag to the comment text
                        comment.Text = comment.Text + " [RegulatoryCompliance:Approved]";
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("File format not supported: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Unsupported operation
            Console.WriteLine("Operation not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}