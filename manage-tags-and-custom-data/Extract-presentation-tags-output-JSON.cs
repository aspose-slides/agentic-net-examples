using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "input.pptx";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(filePath))
            {
                var tags = presentation.CustomData.Tags;
                var tagDictionary = new Dictionary<string, string>();

                for (int i = 0; i < tags.Count; i++)
                {
                    string name = tags.GetNameByIndex(i);
                    string value = tags.GetValueByIndex(i);
                    tagDictionary[name] = value;
                }

                string json = JsonSerializer.Serialize(tagDictionary);
                Console.WriteLine(json);

                // Save the presentation before exiting
                presentation.Save(filePath, SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (PptUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}