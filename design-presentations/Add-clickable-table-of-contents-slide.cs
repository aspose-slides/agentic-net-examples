using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddClickableTOC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Create a new slide for the Table of Contents at the beginning
                Aspose.Slides.ISlide tocSlide = presentation.Slides.InsertClone(0, presentation.Slides[0]);

                // Set a title for the TOC slide
                Aspose.Slides.IAutoShape titleShape = tocSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 20, 600, 50);
                titleShape.AddTextFrame("Table of Contents");
                titleShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
                titleShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;

                // Variables for positioning the list items
                float startY = 80;
                float lineHeight = 30;
                int itemIndex = 0;

                // Iterate through all slides (skip the newly added TOC slide)
                for (int i = 1; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    string headingText = null;

                    // Search for a title placeholder shape on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape.Placeholder != null && shape.Placeholder.Type == PlaceholderType.Title)
                        {
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null)
                            {
                                headingText = autoShape.TextFrame.Text;
                                break;
                            }
                        }
                    }

                    // If a title was found, add an entry to the TOC slide
                    if (!string.IsNullOrEmpty(headingText))
                    {
                        float posY = startY + (itemIndex * lineHeight);
                        Aspose.Slides.IAutoShape entryShape = tocSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, posY, 560, lineHeight);
                        entryShape.AddTextFrame(headingText);
                        entryShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 14;
                        entryShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Left;

                        // Create an internal hyperlink to the target slide
                        try
                        {
                            entryShape.HyperlinkClick = new Aspose.Slides.Hyperlink(slide);
                        }
                        catch (Exception ex)
                        {
                            // Handle any exception that may occur while setting the hyperlink
                            Console.WriteLine("Failed to set hyperlink for slide " + (i + 1) + ": " + ex.Message);
                        }

                        itemIndex++;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (including external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}