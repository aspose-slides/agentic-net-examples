using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PPTX file containing comments
        string inputPath = "Comments1.pptx";
        // Path to the output PPTX file (saved after processing)
        string outputPath = "Comments_out.pptx";

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Iterate through all comment authors in the presentation
            foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
            {
                // Cast to concrete CommentAuthor to access its Comments collection
                CommentAuthor author = (CommentAuthor)commentAuthor;

                // Iterate through each comment made by the current author
                foreach (IComment commentInterface in author.Comments)
                {
                    // Cast to concrete Comment to access its properties
                    Comment comment = (Comment)commentInterface;

                    // Output comment details to the console
                    Console.WriteLine(
                        "ISlide :" + comment.Slide.SlideNumber +
                        " has comment: " + comment.Text +
                        " with Author: " + comment.Author.Name +
                        " posted on time :" + comment.CreatedTime);
                }
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}