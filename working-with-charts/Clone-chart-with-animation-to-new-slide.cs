using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "source.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation sourcePres = new Presentation(inputPath))
            {
                // Get the slide that contains the chart (assumed to be the first slide)
                ISlide sourceSlide = sourcePres.Slides[0];

                // Clone the slide (including the chart and its animation sequence) to the end of the slide collection
                ISlide clonedSlide = sourcePres.Slides.InsertClone(sourcePres.Slides.Count, sourceSlide);

                // Save the modified presentation
                sourcePres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}