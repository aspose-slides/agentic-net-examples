using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Indices of slides to delete (zero‑based). Example: delete slide 2 and slide 4.
            int[] slideIndices = new int[] { 1, 3 };

            // Sort indices in descending order to avoid re‑indexing problems after each removal
            Array.Sort(slideIndices);
            Array.Reverse(slideIndices);

            // Remove each specified slide
            foreach (int index in slideIndices)
            {
                presentation.Slides.RemoveAt(index);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}