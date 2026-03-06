using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing PPTX presentation
        Presentation presentation = new Presentation("input.pptx");

        // List all supported export formats defined in SaveFormat enum
        Array formats = Enum.GetValues(typeof(SaveFormat));
        foreach (SaveFormat format in formats)
        {
            Console.WriteLine(format.ToString());
        }

        // Save the presentation before exiting (as PPTX)
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}