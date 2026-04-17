using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation with embedded binary objects removed (lazy loading of custom data)
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.DeleteEmbeddedBinaryObjects = true;

        try
        {
            using (Presentation presentation = new Presentation(inputPath, loadOptions))
            {
                // Access presentation-level custom data tags only when needed
                ICustomData presentationCustomData = presentation.CustomData;
                if (presentationCustomData.Tags.Contains("Author"))
                {
                    string authorTag = presentationCustomData.Tags["Author"];
                    Console.WriteLine("Author tag: " + authorTag);
                }

                // Iterate through slides and lazily access each slide's custom data
                foreach (ISlide slide in presentation.Slides)
                {
                    ICustomData slideCustomData = slide.CustomData;
                    if (slideCustomData.Tags.Contains("SlideTag"))
                    {
                        string slideTag = slideCustomData.Tags["SlideTag"];
                        Console.WriteLine("Slide " + slide.SlideNumber + " tag: " + slideTag);
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Handle unsupported PPTX format
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Handle unsupported PPT format
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}