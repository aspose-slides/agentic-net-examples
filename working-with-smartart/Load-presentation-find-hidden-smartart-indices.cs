using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input presentation
        string inputPath = "input.pptx";

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a SmartArt object
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                            // Check if the SmartArt shape is hidden
                            if (shape.Hidden)
                            {
                                // Log the slide number (index) where the hidden SmartArt is found
                                Console.WriteLine("Hidden SmartArt found on slide number: " + slide.SlideNumber);
                            }
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}