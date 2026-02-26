using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the tag collection
        Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;

        // Key of the tag to remove
        string tagKey = "MyTag";

        // Remove the tag if it exists
        if (tags.Contains(tagKey))
        {
            tags.Remove(tagKey);
        }

        // Save the modified presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}