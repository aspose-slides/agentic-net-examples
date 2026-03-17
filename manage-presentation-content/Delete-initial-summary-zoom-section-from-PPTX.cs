using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the Summary Zoom frame from the first slide (assumed to be the first shape)
                Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes[0] as Aspose.Slides.ISummaryZoomFrame;
                if (summaryZoom != null)
                {
                    Aspose.Slides.ISummaryZoomSectionCollection collection = summaryZoom.SummaryZoomCollection;

                    // Remove the initial section if it exists
                    if (presentation.Sections.Count > 0)
                    {
                        Aspose.Slides.ISection firstSection = presentation.Sections[0];
                        collection.RemoveSummaryZoomSection(firstSection);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}