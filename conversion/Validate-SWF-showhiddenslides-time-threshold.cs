using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPathWithout = "output_without_hidden.pdf";
        string outputPathWith = "output_with_hidden.pdf";
        double thresholdSeconds = 2.0; // Defined threshold in seconds

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Convert without hidden slides
            Aspose.Slides.Export.PdfOptions pdfOptionsWithout = new Aspose.Slides.Export.PdfOptions();
            pdfOptionsWithout.ShowHiddenSlides = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            presentation.Save(outputPathWithout, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsWithout);
            stopwatch.Stop();
            double timeWithout = stopwatch.Elapsed.TotalSeconds;

            // Convert with hidden slides
            Aspose.Slides.Export.PdfOptions pdfOptionsWith = new Aspose.Slides.Export.PdfOptions();
            pdfOptionsWith.ShowHiddenSlides = true;
            stopwatch.Reset();
            stopwatch.Start();
            presentation.Save(outputPathWith, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsWith);
            stopwatch.Stop();
            double timeWith = stopwatch.Elapsed.TotalSeconds;

            // Output conversion times
            Console.WriteLine($"Conversion time without hidden slides: {timeWithout} seconds");
            Console.WriteLine($"Conversion time with hidden slides: {timeWith} seconds");

            // Check against threshold
            if ((timeWith - timeWithout) > thresholdSeconds)
            {
                Console.WriteLine("Conversion time exceeds the defined threshold.");
            }
            else
            {
                Console.WriteLine("Conversion time is within the acceptable threshold.");
            }

            // Save presentation before exit
            presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
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