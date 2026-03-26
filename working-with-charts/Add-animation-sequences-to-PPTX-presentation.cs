using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Access the main animation sequence of the first slide
            ISequence seq = pres.Slides[0].Timeline.MainSequence;

            // Get the first effect in the sequence
            IEffect effect = seq[0];

            // Enable rewind for the effect
            effect.Timing.Rewind = true;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}