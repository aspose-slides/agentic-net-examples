using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                Console.WriteLine("Slide count: " + docProps.Slides);
                Console.WriteLine("Author: " + docProps.Author);
                Console.WriteLine("Created time (UTC): " + docProps.CreatedTime);

                int customCount = docProps.CountOfCustomProperties;
                Console.WriteLine("Custom properties count: " + customCount);
                for (int i = 0; i < customCount; i++)
                {
                    string propName = docProps.GetCustomPropertyName(i);
                    object propValue = docProps[propName];
                    Console.WriteLine("Custom Property - Name: " + propName + ", Value: " + propValue);
                }

                Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;
                Console.WriteLine("Tag count: " + tags.Count);
                for (int i = 0; i < tags.Count; i++)
                {
                    string tagName = tags.GetNameByIndex(i);
                    string tagValue = tags.GetValueByIndex(i);
                    Console.WriteLine("Tag - Name: " + tagName + ", Value: " + tagValue);
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}