using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace TextBoxDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the input PPTX file
                var inputPath = "input.pptx";
                // Path to the output PPTX file
                var outputPath = "output.pptx";

                // Load the presentation
                using (var presentation = new Presentation(inputPath))
                {
                    // Flag to indicate if any text box was found
                    var textBoxFound = false;

                    // Iterate through all slides
                    foreach (var slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (var shape in slide.Shapes)
                        {
                            // Check if the shape is an AutoShape and is a text box
                            if (shape is IAutoShape autoShape && autoShape.IsTextBox)
                            {
                                textBoxFound = true;

                                // Example modification: prepend a note to the existing text
                                var textFrame = autoShape.TextFrame;
                                if (textFrame != null && textFrame.Text != null)
                                {
                                    textFrame.Text = "[Detected TextBox] " + textFrame.Text;
                                }
                            }
                        }
                    }

                    // Optionally, report detection result
                    Console.WriteLine(textBoxFound
                        ? "Text box shape(s) detected and modified."
                        : "No text box shapes found.");

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}