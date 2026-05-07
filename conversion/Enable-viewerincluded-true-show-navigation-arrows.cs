using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide1 = presentation.Slides[0];

        // Add a second slide by cloning the first slide
        ISlide slide2 = presentation.Slides.AddClone(slide1);

        // Configure SWF options with the integrated viewer included
        SwfOptions swfOptions = new SwfOptions();
        swfOptions.ViewerIncluded = true;

        // Save the presentation as SWF, handling potential format exceptions
        try
        {
            presentation.Save("output.swf", SaveFormat.Swf, swfOptions);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Save the presentation as PPTX before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}