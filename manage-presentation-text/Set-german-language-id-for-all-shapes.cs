using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all shapes on the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                    for (int p = 0; p < textFrame.Paragraphs.Count; p++)
                    {
                        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[p];
                        for (int pt = 0; pt < paragraph.Portions.Count; pt++)
                        {
                            Aspose.Slides.IPortion portion = paragraph.Portions[pt];
                            // Set language metadata to German
                            portion.PortionFormat.LanguageId = "de-DE";
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}