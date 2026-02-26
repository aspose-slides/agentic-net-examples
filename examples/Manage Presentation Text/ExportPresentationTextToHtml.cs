using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationTextExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file and output HTML file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Options for HTML conversion
                Aspose.Slides.Export.TextToHtmlConversionOptions options = new Aspose.Slides.Export.TextToHtmlConversionOptions();

                // StringBuilder to accumulate HTML from all paragraphs
                StringBuilder htmlBuilder = new StringBuilder();

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
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

                                // Export all paragraphs of the shape to HTML
                                string html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
                                htmlBuilder.AppendLine(html);
                            }
                        }
                    }
                }

                // Write the accumulated HTML to the output file
                File.WriteAllText(outputPath, htmlBuilder.ToString());

                // Save the presentation before exiting (optional, as per requirement)
                presentation.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}