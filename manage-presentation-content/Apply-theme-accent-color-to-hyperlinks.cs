using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkThemeColorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Get the first slide (current slide)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // If the shape itself has a hyperlink, set its ColorSource to use theme styles
                if (shape.HyperlinkClick != null)
                {
                    shape.HyperlinkClick.ColorSource = Aspose.Slides.HyperlinkColorSource.Styles;
                }

                // If the shape is an AutoShape, also check text portions for hyperlinks
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                        for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                        {
                            Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];
                            if (portion.PortionFormat.HyperlinkClick != null)
                            {
                                portion.PortionFormat.HyperlinkClick.ColorSource = Aspose.Slides.HyperlinkColorSource.Styles;
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose presentation
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}