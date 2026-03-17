using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the slide containing the Summary Zoom Frame (assumed first slide)
                var slide = presentation.Slides[0];

                // Cast the first shape to ISummaryZoomFrame
                var zoomFrame = slide.Shapes[0] as Aspose.Slides.ISummaryZoomFrame;
                if (zoomFrame != null && presentation.Sections.Count > 0)
                {
                    // Remove the first section from the Summary Zoom Frame
                    var firstSection = presentation.Sections[0];
                    zoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(firstSection);
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