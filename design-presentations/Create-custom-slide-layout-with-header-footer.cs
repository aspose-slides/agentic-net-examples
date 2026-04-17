using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "CustomLayout.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get a blank layout slide to customize
                Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

                // Add a header placeholder at the top of the layout
                Aspose.Slides.IAutoShape headerPlaceholder = layout.PlaceholderManager.AddTextPlaceholder(0f, 0f, 720f, 50f);
                headerPlaceholder.AddTextFrame("Header Text");

                // Add a footer placeholder at the bottom of the layout
                Aspose.Slides.IAutoShape footerPlaceholder = layout.PlaceholderManager.AddTextPlaceholder(0f, 540f, 720f, 50f);
                footerPlaceholder.AddTextFrame("Footer Text");

                // Add a content placeholder in the middle of the layout
                Aspose.Slides.IAutoShape contentPlaceholder = layout.PlaceholderManager.AddContentPlaceholder(50f, 100f, 620f, 400f);

                // Ensure header and footer placeholders are visible on dependent slides
                Aspose.Slides.ILayoutSlideHeaderFooterManager layoutHeaderFooter = layout.HeaderFooterManager;
                layoutHeaderFooter.SetFooterAndChildFootersVisibility(true);
                layoutHeaderFooter.SetDateTimeAndChildDateTimesVisibility(true);
                layoutHeaderFooter.SetSlideNumberAndChildSlideNumbersVisibility(true);

                // Create a new slide based on the custom layout
                Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(layout);

                // Optionally, add some text to the content placeholder on the new slide
                Aspose.Slides.IAutoShape slideContent = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 150f, 500f, 300f);
                slideContent.AddTextFrame("Content goes here.");

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}