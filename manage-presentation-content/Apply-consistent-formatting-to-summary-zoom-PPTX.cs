using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and shapes to find Summary Zoom frames
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.ISummaryZoomFrame summaryZoom)
                    {
                        var collection = summaryZoom.SummaryZoomCollection;

                        // Apply formatting to each Summary Zoom section
                        foreach (Aspose.Slides.ISection section in presentation.Sections)
                        {
                            var zoomSection = collection.GetSummarySection(section);
                            if (zoomSection != null)
                            {
                                // Set title and description
                                zoomSection.Title = "Section: " + section.Name;
                                zoomSection.Description = "Summary for " + section.Name;

                                // Set solid fill color
                                zoomSection.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                zoomSection.FillFormat.SolidFillColor.Color = Color.LightBlue;
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}