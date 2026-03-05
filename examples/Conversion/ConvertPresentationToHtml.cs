using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Add a modern comment to the first slide
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");
            Aspose.Slides.IModernComment comment = author.Comments.AddModernComment(
                "This is a sample modern comment.",
                presentation.Slides[0],
                null,
                new System.Drawing.PointF(100f, 100f),
                System.DateTime.Now);

            // Set up HTML export options with comments included
            Aspose.Slides.Export.HtmlOptions htmlOpt = new Aspose.Slides.Export.HtmlOptions();
            htmlOpt.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("", false);
            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
            // No specific slides layout options required; using default (null)
            htmlOpt.SlidesLayoutOptions = null;

            // Save the presentation as HTML
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}