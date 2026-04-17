using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path (default or from arguments)
        string inputPath = "input.pptx";
        if (args.Length >= 1)
        {
            inputPath = args[0];
        }

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load presentation with format support handling
        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Add a blank slide for the tag relationship diagram
        Aspose.Slides.ISlide diagramSlide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank));

        // Create sample tag shapes
        Aspose.Slides.IAutoShape tagShape1 = (Aspose.Slides.IAutoShape)diagramSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 150, 50);
        tagShape1.TextFrame.Text = "Tag A";

        Aspose.Slides.IAutoShape tagShape2 = (Aspose.Slides.IAutoShape)diagramSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 250, 150, 150, 50);
        tagShape2.TextFrame.Text = "Tag B";

        Aspose.Slides.IAutoShape tagShape3 = (Aspose.Slides.IAutoShape)diagramSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 450, 50, 150, 50);
        tagShape3.TextFrame.Text = "Tag C";

        // Add connectors to illustrate relationships
        Aspose.Slides.IAutoShape connector1 = (Aspose.Slides.IAutoShape)diagramSlide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line,
            tagShape1.X + tagShape1.Width,
            tagShape1.Y + tagShape1.Height / 2,
            tagShape2.X,
            tagShape2.Y + tagShape2.Height / 2);

        Aspose.Slides.IAutoShape connector2 = (Aspose.Slides.IAutoShape)diagramSlide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line,
            tagShape2.X + tagShape2.Width,
            tagShape2.Y + tagShape2.Height / 2,
            tagShape3.X,
            tagShape3.Y + tagShape3.Height / 2);

        // Export the diagram slide as SVG
        string outputSvgPath = "diagram.svg";
        if (args.Length >= 2)
        {
            outputSvgPath = args[1];
        }

        try
        {
            using (FileStream svgStream = File.Create(outputSvgPath))
            {
                diagramSlide.WriteAsSvg(svgStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to write SVG: " + ex.Message);
        }

        // Save the modified presentation
        string outputPptxPath = "output.pptx";
        if (args.Length >= 3)
        {
            outputPptxPath = args[2];
        }
        pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}