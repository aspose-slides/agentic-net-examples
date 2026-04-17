using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Choose the master slide to work with (first master slide)
        int masterIndex = 0;
        if (masterIndex < 0 || masterIndex >= presentation.Masters.Count)
        {
            Console.WriteLine("Invalid master slide index.");
            return;
        }

        IMasterSlide masterSlide = presentation.Masters[masterIndex];

        // Iterate through each layout slide of the selected master slide
        for (int i = 0; i < masterSlide.LayoutSlides.Count; i++)
        {
            ILayoutSlide layoutSlide = masterSlide.LayoutSlides[i];
            ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;

            // Add a text placeholder to the layout slide
            placeholderManager.AddTextPlaceholder(20f, 20f, 500f, 300f);
        }

        // Save the presentation
        string outputPath = "OutputWithPlaceholders.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}