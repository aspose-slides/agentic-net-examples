using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideComparisonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the first presentation
                Presentation sourcePresentation1 = new Presentation("source1.pptx");
                // Load the second presentation
                Presentation sourcePresentation2 = new Presentation("source2.pptx");

                // Get the first slide from each presentation
                ISlide slide1 = sourcePresentation1.Slides[0];
                ISlide slide2 = sourcePresentation2.Slides[0];

                // Compare slides using the Equals method
                bool slidesAreEqual = slide1.Equals(slide2);

                // Create a new presentation to hold the PDF report
                Presentation reportPresentation = new Presentation();

                // Get the first (default) slide of the report presentation
                ISlide reportSlide = reportPresentation.Slides[0];

                // Add a textbox shape with the comparison result
                IAutoShape textBox = reportSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 100);
                textBox.AddTextFrame(slidesAreEqual ? "The slides are identical." : "The slides have visual differences.");

                // Save the report as PDF
                reportPresentation.Save("SlideComparisonReport.pdf", SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}