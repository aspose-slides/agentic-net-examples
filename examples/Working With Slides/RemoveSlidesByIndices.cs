using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Indices of slides to remove (zero‑based)
        List<int> slideIndices = new List<int>();
        slideIndices.Add(1);
        slideIndices.Add(3);
        slideIndices.Add(5);

        // Sort indices in descending order to avoid shifting problems
        slideIndices.Sort();
        slideIndices.Reverse();

        // Remove each slide by index
        foreach (int index in slideIndices)
        {
            presentation.Slides.RemoveAt(index);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}