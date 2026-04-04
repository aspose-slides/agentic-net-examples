using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Disable animations by setting transition type to None and removing auto-advance timing
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    pres.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.None;
                    pres.Slides[i].SlideShowTransition.AdvanceOnClick = true;
                    pres.Slides[i].SlideShowTransition.AdvanceAfterTime = 0;
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}