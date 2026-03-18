using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Presentation())
            {
                // Presentation initialized with one empty slide.
                // Additional slides or content can be added here.

                // Save the presentation to a file.
                presentation.Save("EmptyPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}