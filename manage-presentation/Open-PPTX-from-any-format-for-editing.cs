using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation file
            var inputPath = "input.pptx";

            // Open the presentation using a fully‑qualified type
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // TODO: Add manipulation logic here

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}