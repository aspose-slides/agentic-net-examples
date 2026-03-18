using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // List of source presentations to merge
            var inputFiles = new string[] { "input1.pptx", "input2.pptx", "input3.pptx" };
            var outputFile = "merged_output.pptx";

            // Create a new empty presentation that will hold all slides
            var targetPresentation = new Aspose.Slides.Presentation();

            // Iterate over each source file and copy its slides
            foreach (var file in inputFiles)
            {
                using (var sourcePresentation = new Aspose.Slides.Presentation(file))
                {
                    var slideCount = sourcePresentation.Slides.Count;
                    for (var i = 0; i < slideCount; i++)
                    {
                        var slide = sourcePresentation.Slides[i];
                        targetPresentation.Slides.AddClone(slide);
                    }
                }
            }

            // Save the combined presentation
            targetPresentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}