using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideDuplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Access the slides collection
                ISlideCollection slides = presentation.Slides;

                // Define source slide index (zero‑based) and target insertion index
                int sourceIndex = 0;   // slide to duplicate
                int targetIndex = 2;   // position where the copy will be inserted

                // Retrieve the source slide
                ISlide sourceSlide = slides[sourceIndex];

                // Insert a clone of the source slide at the target index
                slides.InsertClone(targetIndex, sourceSlide);

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}