using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Set up HTML conversion options
        Aspose.Slides.Export.TextToHtmlConversionOptions options = new Aspose.Slides.Export.TextToHtmlConversionOptions();
        options.EncodingName = "UTF-8";

        // StringBuilder to collect generated HTML
        StringBuilder htmlBuilder = new StringBuilder();

        // Iterate through each slide
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through each shape on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Process only AutoShape objects that contain a TextFrame
                if (shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    if (autoShape.TextFrame != null)
                    {
                        Aspose.Slides.IParagraphCollection paragraphs = autoShape.TextFrame.Paragraphs;
                        if (paragraphs.Count > 0)
                        {
                            // Export paragraphs to HTML
                            string html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
                            htmlBuilder.AppendLine(html);
                        }
                    }
                }
            }
        }

        // Write the collected HTML to a file
        File.WriteAllText("output.html", htmlBuilder.ToString());

        // Save the presentation (required before exiting)
        presentation.Save("input_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}