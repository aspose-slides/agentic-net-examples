using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation to a memory stream in PPTX format
        using (MemoryStream stream = new MemoryStream())
        {
            presentation.Save(stream, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to stream. Length: " + stream.Length);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}