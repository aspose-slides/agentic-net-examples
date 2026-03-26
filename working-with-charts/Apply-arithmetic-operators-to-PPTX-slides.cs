using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Iterate through all slides
            foreach (ISlide slide in presentation.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Cast the shape to IAutoShape to access TextFrame
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        // Get the current text
                        string currentText = autoShape.TextFrame.Text;

                        // Try to parse a numeric value from the text
                        double numericValue;
                        if (double.TryParse(currentText, out numericValue))
                        {
                            // Apply an arithmetic operation (e.g., add 10)
                            double newValue = numericValue + 10;

                            // Write the new value back to the text frame
                            autoShape.TextFrame.Text = newValue.ToString();
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}