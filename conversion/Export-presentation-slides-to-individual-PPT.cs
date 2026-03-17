using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the source presentation
                Presentation presentation = new Presentation("input.pptx");

                // Iterate through each slide and export it as an individual PPT file
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    // Slides are 1‑based for the Save method
                    int[] slideNumber = new int[] { index + 1 };
                    string outputPath = $"slide_{index + 1}.ppt";

                    // Save only the specified slide in PPT format
                    presentation.Save(outputPath, slideNumber, Aspose.Slides.Export.SaveFormat.Ppt);
                }

                // Save the original presentation before exiting (optional)
                presentation.Save("full_output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}