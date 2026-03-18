using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the default layout slide
                    Aspose.Slides.ILayoutSlide defaultLayout = presentation.LayoutSlides[0];

                    // Add first slide and set its title
                    Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(defaultLayout);
                    slide1.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 50).TextFrame.Text = "Overview";

                    // Add second slide and set its title
                    Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(defaultLayout);
                    slide2.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 50).TextFrame.Text = "Details";

                    // Create sections using the slides as start points
                    Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide1);
                    Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide2);

                    // Save the presentation to a PPTX file
                    presentation.Save("OverviewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}