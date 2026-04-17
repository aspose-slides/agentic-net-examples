using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Validate that the shape has a placeholder and is an AutoShape before modification
                        if (shape.Placeholder != null && shape is AutoShape autoShape)
                        {
                            // Example modification: change the placeholder text
                            autoShape.TextFrame.Text = "Modified placeholder";
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        // Handle unsupported format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // format not supported
            Console.WriteLine("The presentation format is not supported (PPTX).");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // format not supported
            Console.WriteLine("The presentation format is not supported (PPT).");
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}