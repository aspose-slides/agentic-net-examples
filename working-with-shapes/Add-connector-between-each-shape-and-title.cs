using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        // Input file path (optional command‑line argument)
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        Aspose.Slides.Presentation presentation = null;

        // Load existing presentation if the file exists, otherwise create a new one
        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported (PPTX).");
                return;
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported (PPT).");
                return;
            }
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Process each slide
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Find title placeholder(s) on the slide
            Aspose.Slides.IShape[] titlePlaceholders = Aspose.Slides.Util.SlideUtil.FindShapesByPlaceholderType(
                slide,
                Aspose.Slides.PlaceholderType.Title);

            if (titlePlaceholders.Length == 0)
            {
                // No title placeholder on this slide; skip connector creation
                continue;
            }

            Aspose.Slides.IShape titleShape = titlePlaceholders[0];

            // Get all shapes on the slide
            Aspose.Slides.IShape[] allShapes = slide.Shapes.ToArray();

            foreach (Aspose.Slides.IShape shape in allShapes)
            {
                // Skip the title placeholder itself
                if (shape == titleShape)
                {
                    continue;
                }

                // Add a bent connector shape
                Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(
                    Aspose.Slides.ShapeType.BentConnector2,
                    0,
                    0,
                    10,
                    10);

                // Connect the title placeholder to the current shape
                connector.StartShapeConnectedTo = titleShape;
                connector.EndShapeConnectedTo = shape;

                // Adjust the connector to the shortest path
                connector.Reroute();
            }
        }

        // Save the modified presentation
        string outputPath = "output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}