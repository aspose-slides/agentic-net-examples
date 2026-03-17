using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx"; // can be .ppt or .pptx
            var outputPath = "output.html";

            using (var presentation = new Presentation(inputPath))
            {
                // Save the presentation to HTML format with full slide fidelity
                presentation.Save(outputPath, SaveFormat.Html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}