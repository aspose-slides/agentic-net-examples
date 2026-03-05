using System;
using System.Collections.Generic;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "input.pptx";
        // Path for the resulting presentation
        string outputPath = "output.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // List of slide indices to remove (zero‑based)
            List<int> slideIndices = new List<int> { 1, 3, 5 };

            // Sort indices in descending order to avoid shifting problems
            slideIndices.Sort();
            slideIndices.Reverse();

            // Remove slides at the specified indices
            foreach (int index in slideIndices)
            {
                presentation.Slides.RemoveAt(index);
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}