using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string dataDir = @"C:\Data\";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Indices of slides to delete (zero‑based)
            int[] slideIndices = new int[] { 2, 4, 5 };

            // Sort indices in descending order to avoid shifting problems
            Array.Sort(slideIndices);
            Array.Reverse(slideIndices);

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);

                // Remove slides at specified indices
                foreach (int index in slideIndices)
                {
                    // Ensure index is within range
                    if (index >= 0 && index < presentation.Slides.Count)
                    {
                        presentation.Slides.RemoveAt(index);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Release resources
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}