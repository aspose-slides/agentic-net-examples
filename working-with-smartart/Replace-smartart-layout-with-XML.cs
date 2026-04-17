using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string customLayoutXmlPath = "customLayout.xml";

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file does not exist.");
            return;
        }

        if (!File.Exists(customLayoutXmlPath))
        {
            Console.WriteLine("Custom layout XML file does not exist.");
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Load custom layout from XML (placeholder - actual implementation depends on API support)
        // Here we assume the custom layout corresponds to an existing SmartArtLayoutType
        Aspose.Slides.SmartArt.SmartArtLayoutType customLayout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;

        // Find the first SmartArt shape and replace its layout
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt)
            {
                Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                smartArt.Layout = customLayout;
                break;
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}