using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output_with_comments.pptx";

            using (var presentation = new Presentation(inputPath))
            {
                // Add a comment author
                var author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

                // Position for comments
                var position = new PointF(0.2f, 0.2f);

                // Add a comment to each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var commentText = $"Comment for slide {i + 1}";
                    author.Comments.AddComment(commentText, slide, position, DateTime.Now);
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}