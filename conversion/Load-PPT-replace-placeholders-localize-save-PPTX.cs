using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Replace placeholder text on the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.Placeholder != null)
                {
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Localized Text";
                }
            }

            // Save the modified presentation as PPTX
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or other processing issues
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}