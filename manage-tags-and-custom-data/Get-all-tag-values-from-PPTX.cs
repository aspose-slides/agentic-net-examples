using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RetrieveCustomTags
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Retrieve presentation-level tags
                Aspose.Slides.ITagCollection presTags = presentation.CustomData.Tags;
                int presTagCount = presTags.Count;
                Console.WriteLine("Presentation-level tags:");
                for (int i = 0; i < presTagCount; i++)
                {
                    string tagName = presTags.GetNameByIndex(i);
                    string tagValue = presTags.GetValueByIndex(i);
                    Console.WriteLine($"  {tagName} = {tagValue}");
                }

                // Retrieve slide-level tags
                Aspose.Slides.ISlideCollection slides = presentation.Slides;
                Console.WriteLine("Slide-level tags:");
                for (int s = 0; s < slides.Count; s++)
                {
                    Aspose.Slides.ISlide slide = slides[s];
                    Aspose.Slides.ITagCollection slideTags = slide.CustomData.Tags;
                    int slideTagCount = slideTags.Count;
                    if (slideTagCount > 0)
                    {
                        Console.WriteLine($"  Slide {s + 1}:");
                        for (int t = 0; t < slideTagCount; t++)
                        {
                            string tagName = slideTags.GetNameByIndex(t);
                            string tagValue = slideTags.GetValueByIndex(t);
                            Console.WriteLine($"    {tagName} = {tagValue}");
                        }
                    }
                }

                // Save the presentation (no modifications made)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}