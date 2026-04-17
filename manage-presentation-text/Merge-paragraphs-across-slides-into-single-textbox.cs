using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace MergeParagraphsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "merged_output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Ensure there is at least one slide
                    if (presentation.Slides.Count == 0)
                    {
                        Console.WriteLine("Presentation contains no slides.");
                        return;
                    }

                    // Get the first slide to host the merged text box
                    Aspose.Slides.ISlide targetSlide = presentation.Slides[0];

                    // Create a rectangle shape that will contain the merged paragraphs
                    Aspose.Slides.IAutoShape mergedShape = targetSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
                    mergedShape.AddTextFrame(string.Empty);
                    Aspose.Slides.ITextFrame mergedTextFrame = mergedShape.TextFrame;

                    // Iterate through all slides and collect paragraphs from every text box
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide currentSlide = presentation.Slides[slideIndex];

                        // Retrieve all text frames on the current slide
                        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(currentSlide);

                        foreach (Aspose.Slides.ITextFrame sourceTextFrame in textFrames)
                        {
                            foreach (Aspose.Slides.IParagraph sourceParagraph in sourceTextFrame.Paragraphs)
                            {
                                // Create a new paragraph and copy the plain text
                                Aspose.Slides.Paragraph newParagraph = new Aspose.Slides.Paragraph();
                                newParagraph.Text = sourceParagraph.Text;

                                // Append the new paragraph to the merged text frame
                                mergedTextFrame.Paragraphs.Add(newParagraph);
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (System.Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}