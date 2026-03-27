using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load the presentation from the input file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Change the background color of the first slide to blue
        presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

        // Iterate through shapes on the first slide and set solid red fill for auto shapes
        foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
        {
            if (shape is Aspose.Slides.IAutoShape)
            {
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                autoShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}