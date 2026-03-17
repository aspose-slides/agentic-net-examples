using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SummaryZoomDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output file path
                string resultPath = Path.Combine(Directory.GetCurrentDirectory(), "SummaryZoomDemo.pptx");

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // -----------------------------------------------------------------
                // Create additional slides and sections to work with
                // -----------------------------------------------------------------
                // First slide already exists (index 0)
                Aspose.Slides.ISlide slide1 = presentation.Slides[0];
                slide1.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide1.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide1.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

                // Add second slide
                Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide2.Background.FillFormat.SolidFillColor.Color = Color.LightCoral;

                // Add third slide
                Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide3.Background.FillFormat.SolidFillColor.Color = Color.LightGreen;

                // Create sections for the slides
                Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide1);
                Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide2);
                Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide3);

                // -----------------------------------------------------------------
                // Add a Summary Zoom frame to the first slide
                // -----------------------------------------------------------------
                Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

                // Get the collection of Summary Zoom sections
                Aspose.Slides.ISummaryZoomSectionCollection zoomSectionCollection = summaryZoom.SummaryZoomCollection;

                // Insert Summary Zoom sections for each presentation section
                Aspose.Slides.ISummaryZoomSection addedSection1 = zoomSectionCollection.AddSummaryZoomSection(section1);
                Aspose.Slides.ISummaryZoomSection addedSection2 = zoomSectionCollection.AddSummaryZoomSection(section2);
                Aspose.Slides.ISummaryZoomSection addedSection3 = zoomSectionCollection.AddSummaryZoomSection(section3);

                // -----------------------------------------------------------------
                // Demonstrate removal of a Summary Zoom section
                // -----------------------------------------------------------------
                // Remove the second section from the Summary Zoom collection
                zoomSectionCollection.RemoveSummaryZoomSection(section2);

                // Optionally clear all remaining Summary Zoom sections
                // zoomSectionCollection.Clear();

                // -----------------------------------------------------------------
                // Save the presentation
                // -----------------------------------------------------------------
                presentation.Save(resultPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}