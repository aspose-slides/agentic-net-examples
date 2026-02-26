using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveTagsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Load the presentation from file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through all custom XML parts (tags) and remove them
                Aspose.Slides.ICustomXmlPart[] customXmlParts = presentation.AllCustomXmlParts;
                foreach (Aspose.Slides.ICustomXmlPart part in customXmlParts)
                {
                    part.Remove();
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}