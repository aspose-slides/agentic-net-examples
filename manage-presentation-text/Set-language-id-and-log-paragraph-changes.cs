// -----------------------------------------------------------------------------
// Example: Set language id and log paragraph changes using C#
//
// Description:
// Demonstrates how to detect a simple language for each paragraph in a shape,
// assign the corresponding LanguageId to every portion, and log the changes 
// using Aspose.Slides for .NET. The example loads a PPTX file, processes the 
// first AutoShape on the first slide, applies language identifiers based on a 
// basic Cyrillic check, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, LanguageId, Paragraph, Portion, 
// Logging, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically assign language identifiers to text portions in a presentation.
// - Log language assignment operations for auditing or debugging.
// - Build .NET tools that preprocess PPTX files before publishing or translation.
// - Integrate language detection logic into PowerPoint automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape autoShape = slide.Shapes[0] as Aspose.Slides.IAutoShape;

            if (autoShape != null && autoShape.TextFrame != null)
            {
                for (int p = 0; p < autoShape.TextFrame.Paragraphs.Count; p++)
                {
                    Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[p];
                    string detectedLanguage = DetectLanguage(paragraph.Text);

                    for (int po = 0; po < paragraph.Portions.Count; po++)
                    {
                        Aspose.Slides.IPortion portion = paragraph.Portions[po];
                        portion.PortionFormat.LanguageId = detectedLanguage;
                        Console.WriteLine($"Paragraph {p}, Portion {po} language set to {detectedLanguage}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No suitable AutoShape with text found.");
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string DetectLanguage(string text)
    {
        // Simple placeholder detection: Cyrillic => Russian, otherwise English
        foreach (char c in text)
        {
            if (c >= '\u0400' && c <= '\u04FF')
            {
                return "ru-RU";
            }
        }
        return "en-US";
    }
}
