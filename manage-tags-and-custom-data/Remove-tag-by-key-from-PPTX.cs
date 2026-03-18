using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string tagKey = "MyTag";

            using (Presentation presentation = new Presentation(inputPath))
            {
                ITagCollection tags = presentation.CustomData.Tags;
                if (tags.Contains(tagKey))
                {
                    tags.Remove(tagKey);
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