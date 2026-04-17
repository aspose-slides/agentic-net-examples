using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddHyperlinksBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // The provided file format is not supported by Aspose.Slides.
                return;
            }

            // Batch process each slide
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        // Iterate through paragraphs
                        for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                        {
                            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                            // Iterate through portions (text runs)
                            for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                            {
                                Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];

                                // Set hyperlink using mutable-hyperlink rule
                                Aspose.Slides.Hyperlink hyperlink = new Aspose.Slides.Hyperlink("https://www.example.com");
                                portion.PortionFormat.HyperlinkClick = hyperlink;
                                portion.PortionFormat.HyperlinkClick.Tooltip = "Visit Example";
                                portion.PortionFormat.FontHeight = 12f;
                            }
                        }
                    }
                }
            }

            try
            {
                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}