using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all slides
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Clear main animation sequence
                Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;
                mainSequence.Clear();

                // Clear all interactive sequences
                Aspose.Slides.Animation.ISequenceCollection interactiveSequences = slide.Timeline.InteractiveSequences;
                for (int j = 0; j < interactiveSequences.Count; j++)
                {
                    Aspose.Slides.Animation.ISequence seq = interactiveSequences[j];
                    seq.Clear();
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}