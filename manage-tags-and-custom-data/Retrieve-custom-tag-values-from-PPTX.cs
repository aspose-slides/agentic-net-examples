using System;
using Aspose.Slides.Export;

namespace AsposeSlidesTagReader
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputFile = "input.pptx";
                var outputFile = "output.pptx";

                using (var presentation = new Aspose.Slides.Presentation(inputFile))
                {
                    var tagCollection = presentation.CustomData.Tags;
                    for (int i = 0; i < tagCollection.Count; i++)
                    {
                        var tagName = tagCollection.GetNameByIndex(i);
                        var tagValue = tagCollection.GetValueByIndex(i);
                        Console.WriteLine($"{tagName}: {tagValue}");
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}