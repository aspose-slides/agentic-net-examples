using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var tagToRemove = "MyTag";

            var presentation = new Aspose.Slides.Presentation(inputPath);
            var tags = presentation.CustomData.Tags;

            if (tags.Contains(tagToRemove))
            {
                tags.Remove(tagToRemove);
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}