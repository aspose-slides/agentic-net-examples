using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportParagraphToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string presentationPath = "input.pptx";
            string htmlOutputPath = "output.html";

            // Load the presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first shape that contains a text frame
                IAutoShape autoShape = null;
                foreach (IShape shape in slide.Shapes)
                {
                    autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        break;
                    }
                }

                if (autoShape != null && autoShape.TextFrame != null)
                {
                    // Get the paragraph collection from the text frame
                    IParagraphCollection paragraphs = autoShape.TextFrame.Paragraphs;

                    // Set HTML conversion options
                    TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();

                    // Export all paragraphs to HTML
                    string html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

                    // Write the HTML to a file
                    File.WriteAllText(htmlOutputPath, html);
                }

                // Save the presentation before exiting
                presentation.Save(presentationPath, SaveFormat.Pptx);
            }
        }
    }
}