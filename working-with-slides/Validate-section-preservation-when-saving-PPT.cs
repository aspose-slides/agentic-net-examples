using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.ppt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the original presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Capture original sections
            int originalCount = pres.Sections.Count;
            List<string> originalNames = new List<string>();
            for (int i = 0; i < originalCount; i++)
            {
                originalNames.Add(pres.Sections[i].Name);
            }

            // Save to PPT format
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("PPT format not supported for this presentation.");
                return;
            }

            // Load the saved PPT presentation
            Aspose.Slides.Presentation savedPres = new Aspose.Slides.Presentation(outputPath);

            // Capture saved sections
            int savedCount = savedPres.Sections.Count;
            List<string> savedNames = new List<string>();
            for (int i = 0; i < savedCount; i++)
            {
                savedNames.Add(savedPres.Sections[i].Name);
            }

            // Compare sections and report discrepancies
            if (originalCount != savedCount)
            {
                Console.WriteLine($"Section count mismatch: original={originalCount}, saved={savedCount}");
            }
            else
            {
                bool mismatchFound = false;
                for (int i = 0; i < originalCount; i++)
                {
                    if (originalNames[i] != savedNames[i])
                    {
                        Console.WriteLine($"Section name mismatch at index {i}: original='{originalNames[i]}', saved='{savedNames[i]}'");
                        mismatchFound = true;
                    }
                }
                if (!mismatchFound)
                {
                    Console.WriteLine("All sections preserved correctly.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}