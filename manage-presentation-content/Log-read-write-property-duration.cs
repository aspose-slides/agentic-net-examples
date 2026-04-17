using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Stopwatch readTimer = new Stopwatch();
        Stopwatch writeTimer = new Stopwatch();

        try
        {
            readTimer.Start();
            Presentation presentation = new Presentation(inputPath);
            IDocumentProperties documentProperties = presentation.DocumentProperties;
            Console.WriteLine("Author: " + documentProperties.Author);
            Console.WriteLine("Title: " + documentProperties.Title);
            readTimer.Stop();

            documentProperties.Author = "Diagnostic Tool";
            documentProperties.Title = "Processed Presentation";

            writeTimer.Start();
            presentation.Save(outputPath, SaveFormat.Pptx);
            writeTimer.Stop();

            Console.WriteLine("Read time (ms): " + readTimer.ElapsedMilliseconds);
            Console.WriteLine("Write time (ms): " + writeTimer.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}