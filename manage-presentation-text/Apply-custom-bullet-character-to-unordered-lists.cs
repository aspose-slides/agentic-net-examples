using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Custom bullet character to apply
        char customBulletChar = '\u2022';

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through all slides and shapes
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                    // Iterate through all paragraphs in the text frame
                    foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                    {
                        // Apply custom bullet character to unordered (symbol) bullet lists
                        if (paragraph.ParagraphFormat.Bullet.Type == Aspose.Slides.BulletType.Symbol)
                        {
                            paragraph.ParagraphFormat.Bullet.Char = customBulletChar;
                        }
                    }
                }
            }
        }

        try
        {
            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}