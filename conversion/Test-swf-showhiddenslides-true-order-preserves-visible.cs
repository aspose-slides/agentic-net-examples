using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Hide the first slide to test hidden slide handling
            if (pres.Slides.Count > 0)
            {
                pres.Slides[0].Hidden = true;
            }

            // Save with ShowHiddenSlides = false
            Aspose.Slides.Export.SwfOptions swfOptionsFalse = new Aspose.Slides.Export.SwfOptions();
            swfOptionsFalse.ShowHiddenSlides = false;
            string outputPathFalse = Path.Combine(Environment.CurrentDirectory, "output_false.swf");
            pres.Save(outputPathFalse, Aspose.Slides.Export.SaveFormat.Swf, swfOptionsFalse);

            // Save with ShowHiddenSlides = true
            Aspose.Slides.Export.SwfOptions swfOptionsTrue = new Aspose.Slides.Export.SwfOptions();
            swfOptionsTrue.ShowHiddenSlides = true;
            string outputPathTrue = Path.Combine(Environment.CurrentDirectory, "output_true.swf");
            pres.Save(outputPathTrue, Aspose.Slides.Export.SaveFormat.Swf, swfOptionsTrue);

            // Save the presentation before exiting
            pres.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}