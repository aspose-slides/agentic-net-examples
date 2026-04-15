using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];

            SmartArt smartArt = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is SmartArt)
                {
                    smartArt = (SmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt found in the first slide.");
                pres.Dispose();
                return;
            }

            int nodeIndex = 0;
            foreach (ISmartArtNode node in smartArt.AllNodes)
            {
                if (node.Shapes.Count == 0)
                {
                    nodeIndex++;
                    continue;
                }

                IShape nodeShape = node.Shapes[0];

                // Add overlay rectangle with watermark text (node index)
                IAutoShape overlay = slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    nodeShape.X,
                    nodeShape.Y,
                    nodeShape.Width,
                    nodeShape.Height);

                overlay.AddTextFrame(nodeIndex.ToString());
                overlay.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
                overlay.FillFormat.FillType = FillType.NoFill;
                overlay.LineFormat.FillFormat.FillType = FillType.NoFill;

                // Generate thumbnail of the overlay shape (includes watermark)
                IImage shapeImage = overlay.GetImage(
                    ShapeThumbnailBounds.Shape,
                    1f,
                    1f);

                string outputPng = $"node_{nodeIndex}.png";
                shapeImage.Save(outputPng, ImageFormat.Png);

                // Clean up overlay shape
                slide.Shapes.Remove(overlay);
                nodeIndex++;
            }

            // Save the modified presentation before exit
            pres.Save("output.pptx", SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}