using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Presentation(inputPath))
            {
                // Replace all occurrences of "Old Text" with "New Text"
                presentation.ReplaceText("Old Text", "New Text", null, null);

                // Save the modified presentation in PPTX format
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}