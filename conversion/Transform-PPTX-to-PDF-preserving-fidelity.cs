using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Convert and save the presentation as PDF
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}