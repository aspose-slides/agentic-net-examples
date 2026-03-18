using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Highlight the specified text with yellow color
                Color highlightColor = Color.Yellow;
                presentation.HighlightText("Hello", highlightColor);

                // Save the updated presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}