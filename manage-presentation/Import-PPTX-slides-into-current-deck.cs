using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation that will hold the combined slides
            using (Presentation destination = new Presentation())
            {
                // Load the external PPTX file
                using (Presentation source = new Presentation("source.pptx"))
                {
                    // Iterate through each slide in the source presentation
                    for (int index = 0; index < source.Slides.Count; index++)
                    {
                        // Clone the slide into the destination presentation, preserving formatting
                        destination.Slides.AddClone(source.Slides[index]);
                    }
                }

                // Save the combined presentation to disk
                destination.Save("CombinedPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}