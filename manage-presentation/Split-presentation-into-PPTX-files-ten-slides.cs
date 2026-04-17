using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input presentation path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            using (Presentation sourcePres = new Presentation(inputPath))
            {
                int totalSlides = sourcePres.Slides.Count;
                int partNumber = 0;

                // Process slides in batches of 10
                for (int startIndex = 0; startIndex < totalSlides; startIndex += 10)
                {
                    partNumber++;

                    // Create a new presentation (create-new-presentation rule)
                    Presentation partPres = new Presentation();

                    // Add a line shape as shown in the rule (optional, will be removed later)
                    partPres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

                    // Remove the default empty slide created by the constructor
                    partPres.Slides.RemoveAt(0);

                    // Determine how many slides to copy in this batch
                    int batchCount = Math.Min(10, totalSlides - startIndex);

                    // Clone slides from the source presentation into the new one
                    for (int i = 0; i < batchCount; i++)
                    {
                        partPres.Slides.AddClone(sourcePres.Slides[startIndex + i]);
                    }

                    // Define output file name for this batch
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"output_part_{partNumber}.pptx");

                    // Save the split presentation (save rule)
                    partPres.Save(outputPath, SaveFormat.Pptx);

                    // Dispose the split presentation
                    partPres.Dispose();
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}