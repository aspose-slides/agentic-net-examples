// -----------------------------------------------------------------------------
// Example: Retrieve Slide by Persistent ID and Assign Custom Tags
//
// Description:
// Demonstrates loading a PPTX file, retrieving a slide using its persistent
// ID, adding custom metadata tags to the slide, and saving the updated
// presentation. Useful for automating slide metadata management in PowerPoint
// files using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide ID, Custom Tags, Metadata
//
// Use Cases:
// - Retrieve a specific slide using its persistent ID.
// - Add or modify custom tags on a slide for metadata tracking.
// - Automate PPTX metadata updates in batch processing tools.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            if (!File.Exists(inputPath))
            {
                using (Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation())
                {
                    samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                Environment.Exit(1);
            }

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                System.UInt32 slideId = presentation.Slides[0].SlideId;

                Aspose.Slides.IBaseSlide baseSlide = presentation.GetSlideById(slideId);
                Aspose.Slides.ISlide slide = (Aspose.Slides.ISlide)baseSlide;

                slide.CustomData.Tags["Tag1"] = "Value1";
                slide.CustomData.Tags.Add("Tag2", "Value2");

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
