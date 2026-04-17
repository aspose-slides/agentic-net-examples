using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Path to the input presentation file
        string inputPath = "input.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation into a memory stream
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(memoryStream))
                    {
                        // Get the first slide
                        Aspose.Slides.ISlide slide = pres.Slides[0];

                        // Assume the first shape on the slide is a SmartArt diagram
                        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes[0] as Aspose.Slides.SmartArt.ISmartArt;

                        if (smartArt != null && smartArt.Nodes.Count > 0)
                        {
                            // Get the first node of the SmartArt
                            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes[0];

                            if (node.Shapes.Count > 0)
                            {
                                // Get the first shape associated with the node
                                Aspose.Slides.IShape nodeShape = node.Shapes[0];

                                // Set the fill to a semi‑transparent color (50% opacity blue)
                                nodeShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                nodeShape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 0, 0, 255);
                            }
                        }

                        // Save the modified presentation back to the memory stream
                        memoryStream.SetLength(0);
                        pres.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx);

                        // Optionally write the stream to an output file
                        File.WriteAllBytes("output.pptx", memoryStream.ToArray());
                    }
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}