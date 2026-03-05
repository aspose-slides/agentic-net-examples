using System;
using System.Drawing;

namespace AsposeSlidesZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Add two more empty slides based on the layout of the first slide
            Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISlide thirdSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Create sections and associate them with the newly added slides
            Aspose.Slides.ISection sectionOne = presentation.Sections.AddSection("Section One", secondSlide);
            Aspose.Slides.ISection sectionTwo = presentation.Sections.AddSection("Section Two", thirdSlide);

            // -------------------------------------------------
            // Add a Slide Zoom Frame that links to the second slide
            // -------------------------------------------------
            Aspose.Slides.IZoomFrame slideZoom = firstSlide.Shapes.AddZoomFrame(150f, 20f, 100f, 100f, secondSlide);
            slideZoom.ReturnToParent = true; // Enable return to parent slide after zoom

            // -------------------------------------------------
            // Add a Section Zoom Frame that links to the first section
            // -------------------------------------------------
            Aspose.Slides.ISectionZoomFrame sectionZoom = firstSlide.Shapes.AddSectionZoomFrame(300f, 20f, 100f, 100f, sectionOne);
            sectionZoom.ReturnToParent = true;

            // -------------------------------------------------
            // Add a Summary Zoom Frame that aggregates all sections
            // -------------------------------------------------
            Aspose.Slides.ISummaryZoomFrame summaryZoom = firstSlide.Shapes.AddSummaryZoomFrame(450f, 20f, 300f, 200f);
            // Optionally, customize the summary zoom collection (e.g., add a new summary zoom section)
            Aspose.Slides.ISummaryZoomSection newSummarySection = summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(sectionTwo);
            newSummarySection.Title = "Custom Section Title";

            // Save the presentation in PPTX format
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ZoomFramesExample.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}