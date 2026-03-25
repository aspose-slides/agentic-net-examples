using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyArithmeticOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through each shape on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Process only AutoShape objects that contain a TextFrame
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            ITextFrame textFrame = autoShape.TextFrame;
                            string originalText = textFrame.Text;

                            // Replace each integer number with the result of adding 5 (example arithmetic)
                            string updatedText = Regex.Replace(originalText, @"\b\d+\b", match =>
                            {
                                int number = int.Parse(match.Value);
                                int result = number + 5; // Example arithmetic operation
                                return result.ToString();
                            });

                            // Update the text if it has changed
                            if (!originalText.Equals(updatedText))
                            {
                                textFrame.Text = updatedText;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
    }
}