using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var author = presentation.CommentAuthors.AddAuthor("Author Name", "AN");
            var comment = author.Comments.AddModernComment(
                "This is a comment with shadow",
                slide,
                null,
                new PointF(100, 100),
                DateTime.Now);

            var commentShape = comment.Shape;
            if (commentShape != null)
            {
                commentShape.EffectFormat.EnableOuterShadowEffect();
                var outerShadow = commentShape.EffectFormat.OuterShadowEffect;
                outerShadow.BlurRadius = 5.0;
                outerShadow.Distance = 3.0;
                outerShadow.Direction = 45.0f;
                outerShadow.ShadowColor.Color = Color.Black;
            }

            var outputPath = "CommentShadow.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}