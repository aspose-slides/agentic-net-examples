using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data/";
        string inputPath = dataDir + "input.pptx";
        string outputPath = dataDir + "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Obtain the persistent ID of the first slide (example)
                System.UInt32 slideId = presentation.Slides[0].SlideId;

                // Access the slide by its persistent ID
                IBaseSlide slide = presentation.GetSlideById(slideId);

                // Update custom tags on the slide
                slide.CustomData.Tags["Tag1"] = "Value1";
                slide.CustomData.Tags.Add("Tag2", "Value2");

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // If the exception is due to an unsupported format, note it
            // (In a real scenario, check the exception type/message)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}