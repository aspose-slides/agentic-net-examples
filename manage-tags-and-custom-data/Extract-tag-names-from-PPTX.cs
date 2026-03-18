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
            var tagName = "MyTag";

            using (var presentation = new Presentation(inputPath))
            {
                var tags = presentation.CustomData.Tags;
                if (tags.Contains(tagName))
                {
                    tags.Remove(tagName);
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}