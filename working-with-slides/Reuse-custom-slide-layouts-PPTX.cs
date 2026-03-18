using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideLayoutDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the global layout slide collection
                Aspose.Slides.IGlobalLayoutSlideCollection layoutCollection = presentation.LayoutSlides;

                // Get the first master slide in the presentation
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                // Add a new custom layout to the master slide
                Aspose.Slides.ILayoutSlide newLayout = layoutCollection.Add(masterSlide, Aspose.Slides.SlideLayoutType.Custom, "MyCustomLayout");

                // Rename the newly added layout
                newLayout.Name = "RenamedCustomLayout";

                // Clone the first existing layout slide
                Aspose.Slides.ILayoutSlide firstLayout = layoutCollection[0];
                Aspose.Slides.ILayoutSlide clonedLayout = layoutCollection.AddClone(firstLayout);

                // Remove any unused layout slides
                layoutCollection.RemoveUnused();

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}