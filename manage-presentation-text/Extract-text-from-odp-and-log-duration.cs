using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist.");
            return;
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.odp");
        foreach (string filePath in files)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                continue;
            }

            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(filePath, Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                stopwatch.Stop();
                Console.WriteLine($"Processed {Path.GetFileName(filePath)} in {stopwatch.ElapsedMilliseconds} ms.");

                for (int i = 0; i < presentationText.SlidesText.Length; i++)
                {
                    Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                    Console.WriteLine($"Slide {i + 1}: {slideText.Text}");
                }

                // Save presentation before exit as required
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath))
                {
                    pres.Save(filePath, Aspose.Slides.Export.SaveFormat.Odp);
                }
            }
            catch (Exception ex)
            {
                // If file format not supported, handle accordingly
                Console.WriteLine($"Error processing {filePath}: {ex.Message}");
            }
        }
    }
}