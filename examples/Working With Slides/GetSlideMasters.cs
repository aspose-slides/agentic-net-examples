using System;
using Aspose.Slides;

namespace SlideMasterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the collection of master slides
            Aspose.Slides.IMasterSlideCollection masters = presentation.Masters;

            // Output the number of master slides
            Console.WriteLine("Number of master slides: " + masters.Count);

            // Iterate through each master slide and display its name
            for (int i = 0; i < masters.Count; i++)
            {
                Aspose.Slides.IMasterSlide masterSlide = masters[i];
                Console.WriteLine("Master slide " + i + " name: " + masterSlide.Name);
            }

            // Save the presentation (no changes made, just demonstrating save before exit)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}