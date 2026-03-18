using Aspose.Slides;
using Aspose.Slides.Export;
using System;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Indices of slides to duplicate (0‑based)
                int[] slideIndices = new int[] { 0, 1 };

                foreach (int index in slideIndices)
                {
                    ISlide sourceSlide = presentation.Slides[index];
                    // Clone the slide and add it to the end of the collection
                    presentation.Slides.AddClone(sourceSlide);
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}