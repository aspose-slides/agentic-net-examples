using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (var authorObj in presentation.CommentAuthors)
                {
                    var author = (Aspose.Slides.ICommentAuthor)authorObj;
                    while (author.Comments.Count > 0)
                    {
                        var comment = author.Comments[0];
                        comment.Remove();
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}