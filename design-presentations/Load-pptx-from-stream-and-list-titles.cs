using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Presentation presentation = new Presentation(fileStream))
                {
                    // Enumerate slide titles
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IShape[] titleShapes = SlideUtil.FindShapesByPlaceholderType(slide, PlaceholderType.Title);
                        foreach (IShape shape in titleShapes)
                        {
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                string titleText = autoShape.TextFrame.Text;
                                Console.WriteLine($"Slide {i + 1} Title: {titleText}");
                            }
                        }
                    }

                    // Save presentation before exit
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}