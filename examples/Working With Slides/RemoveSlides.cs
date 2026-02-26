using System;
using System.Collections.Generic;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";
        // Path to the output presentation file
        string outputPath = "output.pptx";

        // Indices of slides to remove (zero‑based)
        List<int> indicesToRemove = new List<int> { 1, 3, 5 };

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Get the slides collection
            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            // Sort indices in descending order to avoid shifting issues
            indicesToRemove.Sort();
            for (int i = indicesToRemove.Count - 1; i >= 0; i--)
            {
                int index = indicesToRemove[i];
                // Validate index range
                if (index >= 0 && index < slides.Count)
                {
                    // Remove slide at the specified index
                    slides.RemoveAt(index);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}