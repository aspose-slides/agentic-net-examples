using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputPath = args[1];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Process only AutoShape objects that contain a TextFrame
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                            // Replace each paragraph's bullet with a numbered bullet, preserving depth
                            for (int i = 0; i < textFrame.Paragraphs.Count; i++)
                            {
                                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[i];
                                paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                                // Keep existing indentation level (Depth) unchanged
                                paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)1;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}