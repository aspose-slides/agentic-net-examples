using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure the data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Load existing presentation if it exists, otherwise create a new one
        Aspose.Slides.Presentation pres;
        if (File.Exists(inputPath))
        {
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported
                pres = new Aspose.Slides.Presentation();
            }
        }
        else
        {
            pres = new Aspose.Slides.Presentation();
        }

        // Get slide collection and initial count
        Aspose.Slides.ISlideCollection slides = pres.Slides;
        int initialCount = slides.Count;
        Console.WriteLine("Initial slide count: " + initialCount);

        // Add a clone of the first slide to the end
        slides.AddClone(slides[0]);
        int afterAddCount = slides.Count;
        Console.WriteLine("After adding clone: " + afterAddCount);

        // Remove slide at index 1 if it exists
        if (afterAddCount > 1)
        {
            slides.RemoveAt(1);
        }
        int afterRemoveCount = slides.Count;
        Console.WriteLine("After removing slide at index 1: " + afterRemoveCount);

        // Insert a clone of the first slide at position 0
        slides.InsertClone(0, slides[0]);
        int afterInsertCount = slides.Count;
        Console.WriteLine("After inserting clone at position 0: " + afterInsertCount);

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}