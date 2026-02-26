using System;
using System.Drawing;
using Aspose.Slides.Export;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string inputPath = "input.pptx";
            string commentedPath = "commented.pptx";
            string outputHtmlPath = "output.html";

            // Load the original presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Add a modern comment (author and comment) to the first slide
            Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("John Doe", "JD");
            Aspose.Slides.IModernComment comment = author.Comments.AddModernComment(
                "This is a modern comment with HTML export support.",
                pres.Slides[0],
                null,
                new PointF(100f, 100f),
                DateTime.Now);

            // Save the presentation with the comment (required before HTML conversion)
            pres.Save(commentedPath, SaveFormat.Pptx);
            pres.Dispose();

            // Load the presentation that now contains comments
            Aspose.Slides.Presentation presWithComments = new Aspose.Slides.Presentation(commentedPath);

            // Set up HTML export options (default options are sufficient for comments)
            Aspose.Slides.Export.HtmlOptions htmlOpt = new Aspose.Slides.Export.HtmlOptions();
            // Use a simple document formatter (no CSS, slide titles shown)
            htmlOpt.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("", true);

            // Convert to HTML, comments will be included in the output
            presWithComments.Save(outputHtmlPath, SaveFormat.Html, htmlOpt);

            // Ensure the presentation is saved before exiting
            presWithComments.Dispose();
        }
    }
}