using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Set custom footer text and make it visible on all slides
                presentation.HeaderFooterManager.SetAllFootersText("Company Confidential");
                presentation.HeaderFooterManager.SetAllFootersVisibility(true);

                // Set custom header text and make it visible on all slides
                presentation.HeaderFooterManager.SetAllHeadersText("Quarterly Report");
                presentation.HeaderFooterManager.SetAllHeadersVisibility(true);

                // Ensure slide numbers are visible on all slides
                presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

                // Set header text in master notes slide if it exists
                Aspose.Slides.IMasterNotesSlide masterNotes = presentation.MasterNotesSlideManager.MasterNotesSlide;
                if (masterNotes != null)
                {
                    foreach (Aspose.Slides.IShape shape in masterNotes.Shapes)
                    {
                        if (shape.Placeholder != null && shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Header)
                        {
                            ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Notes Header";
                        }
                    }
                }

                // Save the presentation
                string outputPath = "CustomHeaderFooterPresentation.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}