using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        using (Presentation presentation = new Presentation("input.pptx"))
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Get the first shape on the slide (assumed to contain text)
            IShape shape = slide.Shapes[0];

            // Cast the shape to AutoShape to access its TextFrame
            IAutoShape autoShape = shape as IAutoShape;
            if (autoShape != null && autoShape.TextFrame != null)
            {
                // Get the collection of paragraphs from the TextFrame
                IParagraphCollection paragraphs = autoShape.TextFrame.Paragraphs;

                // Create default options for HTML conversion
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();

                // Export all paragraphs to HTML
                string html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

                // Write the generated HTML to a file
                File.WriteAllText("output.html", html);
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}