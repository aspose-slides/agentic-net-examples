using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Source file not found: {sourcePath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Zero‑based slide index to process
                    int slideIndex = 0;

                    // Ensure the index is within range
                    if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                    {
                        Console.WriteLine($"Slide index {slideIndex} is out of range.");
                        return;
                    }

                    // Access the slide by index
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape has a placeholder
                        if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                        {
                            // Replace placeholder text with actual content
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            autoShape.TextFrame.Text = "Replaced Content";
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine($"Unsupported PPTX format: {ex.Message}");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine($"Unsupported PPT format: {ex.Message}");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}