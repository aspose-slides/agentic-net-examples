using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "destination.pptx";

            // Load the source presentation
            using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Create a new (empty) destination presentation
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Remove the default empty slide that is created automatically
                    destPres.Slides.RemoveAt(0);

                    // Indices of slides to import from the source (0‑based)
                    int[] slideIndices = new int[] { 0, 2 };

                    // Clone each selected slide into the destination presentation
                    foreach (int index in slideIndices)
                    {
                        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[index];
                        destPres.Slides.AddClone(sourceSlide);
                    }

                    // Save the resulting presentation
                    destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}