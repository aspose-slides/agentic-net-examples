using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteTagExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input and output presentation files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            // Name of the tag to be removed
            string tagName = "MyTag";

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access the tag collection from the presentation's custom data
                    ITagCollection tags = presentation.CustomData.Tags;

                    // Check if the tag exists before attempting removal
                    if (tags.Contains(tagName))
                    {
                        tags.Remove(tagName);
                        Console.WriteLine($"Tag '{tagName}' removed.");
                    }
                    else
                    {
                        Console.WriteLine($"Tag '{tagName}' not found.");
                    }

                    // Save the updated presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}