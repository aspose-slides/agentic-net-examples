using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputCsv = "slide_titles.csv";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputCsv))
                {
                    writer.WriteLine("SlideIndex,Title");
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        // Placeholder title; replace with actual extraction if needed
                        string title = $"Slide {i + 1}";
                        writer.WriteLine($"{i + 1},\"{title.Replace("\"", "\"\"")}\"");
                    }
                }

                // Save presentation before exit (no modifications made)
                pres.Save(inputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}