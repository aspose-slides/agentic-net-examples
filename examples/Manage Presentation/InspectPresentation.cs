using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Load the presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Output total number of slides
        int slideCount = presentation.Slides.Count;
        Console.WriteLine("Number of slides: " + slideCount);

        // Iterate through each slide
        for (int i = 0; i < slideCount; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            Console.WriteLine("Slide " + (i + 1) + ":");

            // Iterate through each shape on the slide
            for (int j = 0; j < slide.Shapes.Count; j++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[j];

                // Check if the shape is an AutoShape (which can contain text)
                if (shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    if (autoShape.TextFrame != null)
                    {
                        string text = autoShape.TextFrame.Text;
                        Console.WriteLine("  Shape " + (j + 1) + " text: " + text);
                    }
                }
                else if (shape is Aspose.Slides.ITable)
                {
                    // Example handling for a table shape
                    Console.WriteLine("  Shape " + (j + 1) + " is a table.");
                }
                else
                {
                    // Other shape types can be handled here
                    Console.WriteLine("  Shape " + (j + 1) + " type: " + shape.GetType().Name);
                }
            }
        }

        // Save a copy of the presentation before exiting
        string outputPath = "output_copy.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}