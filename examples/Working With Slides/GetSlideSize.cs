using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve the slide size (dimensions in points)
        SizeF slideSize = presentation.SlideSize.Size;

        // Output the width and height of the slides
        Console.WriteLine("Slide width: {0} points", slideSize.Width);
        Console.WriteLine("Slide height: {0} points", slideSize.Height);

        // Save the presentation (even if unchanged) before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}