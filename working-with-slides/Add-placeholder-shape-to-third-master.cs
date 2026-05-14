using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Ensure there are at least three master slides
        if (presentation.Masters.Count < 3)
        {
            while (presentation.Masters.Count < 3)
            {
                presentation.Masters.AddClone(presentation.Masters[0]);
            }
        }

        // Get the third master slide (index 2)
        IMasterSlide master = presentation.Masters[2];

        // Get the first layout slide of this master
        ILayoutSlide layout = master.LayoutSlides[0];

        // Add a text placeholder with predefined dimensions
        IAutoShape placeholder = layout.PlaceholderManager.AddTextPlaceholder(50f, 50f, 400f, 100f);

        // Add text to the placeholder
        placeholder.AddTextFrame("This is a placeholder on the third master.");

        // Save the presentation
        string outputPath = "Output.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}