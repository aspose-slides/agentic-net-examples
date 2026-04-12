using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        try
        {
            using (var pres = new Presentation(inputPath))
            {
                foreach (var slide in pres.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null && autoShape.Placeholder != null && autoShape.Placeholder.Type == PlaceholderType.Subtitle)
                        {
                            var textFrame = autoShape.TextFrame;
                            foreach (var paragraph in textFrame.Paragraphs)
                            {
                                foreach (var portion in paragraph.Portions)
                                {
                                    var format = portion.PortionFormat;
                                    format.FillFormat.FillType = FillType.Solid;
                                    var originalColor = format.FillFormat.SolidFillColor.Color;
                                    format.FillFormat.SolidFillColor.Color = Color.FromArgb(191, originalColor);
                                }
                            }
                        }
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // format not supported
            Console.WriteLine("PPTX format not supported: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("PPT format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}