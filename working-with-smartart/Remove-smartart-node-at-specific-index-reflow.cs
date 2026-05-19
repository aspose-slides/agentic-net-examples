using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RemoveSmartArtNode
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";
            string outputFile = "output.pptx";
            int nodeIndexToRemove = 2; // zero‑based index

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
                {
                    // Ensure there is at least one slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a SmartArt diagram if none exists (for demonstration)
                    Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                        20f, 20f, 600f, 500f,
                        Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

                    // Remove the node at the specified index; the diagram will automatically reflow
                    smartArt.AllNodes.RemoveNode(nodeIndexToRemove);

                    // Save the presentation
                    try
                    {
                        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                        Console.WriteLine("The requested save format is not supported.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}