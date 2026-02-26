using System;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Retrieve the slide size object
            Aspose.Slides.ISlideSize slideSize = presentation.SlideSize;
            // Get the dimensions in points
            SizeF size = slideSize.Size;

            // Output the width and height
            Console.WriteLine("Slide width: {0} points", size.Width);
            Console.WriteLine("Slide height: {0} points", size.Height);

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}