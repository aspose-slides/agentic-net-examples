using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSlides
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                // Path to the source presentation
                string inputPath = "input.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    // Retrieve the slide object
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Example placeholder for any slide manipulation
                    // (e.g., analyze shapes, modify content, etc.)

                    // Save the individual slide as a separate PPTX file
                    int[] slideIndices = new int[] { i + 1 }; // Slides are 1‑based for saving
                    string outputPath = $"slide_{i + 1}.pptx";
                    presentation.Save(outputPath, slideIndices, SaveFormat.Pptx);
                }

                // Save the (potentially modified) original presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);

                // Clean up resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}