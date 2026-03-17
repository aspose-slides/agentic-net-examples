using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace StripAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Specify the slide index (0‑based)
                int slideIndex = 0;

                // Get the target slide
                ISlide slide = presentation.Slides[slideIndex];

                // Access the main animation sequence of the slide
                ISequence mainSequence = slide.Timeline.MainSequence;

                // Remove all animation effects from the sequence
                mainSequence.Clear();

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}