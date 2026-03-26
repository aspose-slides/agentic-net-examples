using System;
using System.IO;
using Aspose.Slides.Export;

namespace StandardizeTextInPresentation
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

            // Predefined text constants to inject
            const string StandardHeader = "Company Header";
            const string StandardFooter = "Confidential";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and replace text in AutoShapes
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                    {
                        // Example logic: set header text for shapes containing placeholder "[Header]"
                        // and footer text for shapes containing placeholder "[Footer]".
                        // Otherwise, replace all text with the standard header.
                        string currentText = autoShape.TextFrame.Text;
                        if (currentText != null && currentText.Contains("[Header]"))
                        {
                            autoShape.TextFrame.Text = StandardHeader;
                        }
                        else if (currentText != null && currentText.Contains("[Footer]"))
                        {
                            autoShape.TextFrame.Text = StandardFooter;
                        }
                        else
                        {
                            autoShape.TextFrame.Text = StandardHeader;
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}