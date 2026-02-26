using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the collection of master slides
        Aspose.Slides.IMasterSlideCollection masterSlides = presentation.Masters;

        // Access the first master slide
        Aspose.Slides.IMasterSlide firstMaster = masterSlides[0];

        // Output the name of the master slide
        Console.WriteLine("First master slide name: " + firstMaster.Name);

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}