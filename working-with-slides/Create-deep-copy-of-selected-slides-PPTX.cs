using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string dataDir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Data");
            string inputFile = System.IO.Path.Combine(dataDir, "input.pptx");
            string outputFile = System.IO.Path.Combine(dataDir, "output.pptx");

            // Load the source presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile))
            {
                // Get the slide collection
                Aspose.Slides.ISlideCollection slides = pres.Slides;

                // Clone the first slide to the end of the presentation
                slides.AddClone(slides[0]);

                // Clone the second slide (index 1) and insert it at position 2 (zero‑based index)
                slides.InsertClone(2, slides[1]);

                // Save the modified presentation
                pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}