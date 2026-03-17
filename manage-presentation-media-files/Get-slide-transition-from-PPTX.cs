using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            using (Presentation pres = new Presentation(presentationPath))
            {
                var slideIndex = 0; // index of the slide to inspect
                if (slideIndex < 0 || slideIndex >= pres.Slides.Count)
                {
                    Console.WriteLine("Invalid slide index.");
                }
                else
                {
                    var slide = pres.Slides[slideIndex];
                    var transition = slide.SlideShowTransition;

                    Console.WriteLine($"Slide {slideIndex + 1} Transition Type: {transition.Type}");
                    Console.WriteLine($"Duration (ms): {transition.Duration}");
                    Console.WriteLine($"Advance On Click: {transition.AdvanceOnClick}");
                    Console.WriteLine($"Advance After Time (ms): {transition.AdvanceAfterTime}");
                }

                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}