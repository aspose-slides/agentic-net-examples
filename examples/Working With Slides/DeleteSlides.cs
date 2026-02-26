using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Indices of slides to delete (zero‑based)
            int[] indicesToDelete = new int[] { 2, 4, 5 };

            // Sort indices in descending order to avoid reindexing issues
            Array.Sort(indicesToDelete);
            Array.Reverse(indicesToDelete);

            // Remove each specified slide
            foreach (int index in indicesToDelete)
            {
                if (index >= 0 && index < presentation.Slides.Count)
                {
                    presentation.Slides.RemoveAt(index);
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}