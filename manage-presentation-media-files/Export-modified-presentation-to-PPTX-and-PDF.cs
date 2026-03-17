using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Save the presentation in PPTX format
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Save the same presentation in PDF format
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}