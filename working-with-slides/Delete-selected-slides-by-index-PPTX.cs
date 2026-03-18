using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Zero‑based indices of slides to delete
            int[] slidesToDelete = new int[] { 1, 3, 5 };

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Sort indices in descending order to avoid shifting issues
                Array.Sort(slidesToDelete);
                for (int i = slidesToDelete.Length - 1; i >= 0; i--)
                {
                    int index = slidesToDelete[i];
                    if (index >= 0 && index < presentation.Slides.Count)
                    {
                        presentation.Slides.RemoveAt(index);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}