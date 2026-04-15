using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Collect indices of slides to delete (example: delete every second slide)
                System.Collections.Generic.List<int> indicesToDelete = new System.Collections.Generic.List<int>();
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    if ((i + 1) % 2 == 0) // 1‑based slide number is even
                    {
                        indicesToDelete.Add(i);
                    }
                }

                // Delete slides starting from the highest index to keep remaining indices valid
                for (int j = indicesToDelete.Count - 1; j >= 0; j--)
                {
                    int slideIndex = indicesToDelete[j];
                    presentation.Slides[slideIndex].Remove();
                }

                // Remove unused layout slides after bulk deletion
                presentation.LayoutSlides.RemoveUnused();

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
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