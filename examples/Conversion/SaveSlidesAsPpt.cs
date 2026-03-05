using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Iterate through all slides
            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                // Save each slide as an individual PPT file (slide numbers start at 1)
                int[] slideIndices = new int[] { i + 1 };
                string outputPath = $"slide_{i + 1}.ppt";
                presentation.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Ppt);
            }

            // Save the full presentation before exiting
            presentation.Save("full_output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}