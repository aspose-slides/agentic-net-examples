using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var outputPath = "ModernComments.pptx";
            using (var presentation = new Aspose.Slides.Presentation())
            {
                var slide = presentation.Slides[0];
                var author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");
                var comment = author.Comments.AddModernComment(
                    "This is a modern comment",
                    slide,
                    null,
                    new PointF(100, 100),
                    DateTime.Now);
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}