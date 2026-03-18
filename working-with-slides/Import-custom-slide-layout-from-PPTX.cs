using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation that contains the desired layout
            string sourcePath = "source.pptx";
            Presentation sourcePresentation = new Presentation(sourcePath);

            // Get the first master slide from the source presentation
            IMasterSlide sourceMaster = sourcePresentation.Masters[0];

            // Create a new presentation where the custom layout will be applied
            Presentation targetPresentation = new Presentation();

            // Add a custom layout slide to the target presentation using the source master slide
            ILayoutSlide customLayout = targetPresentation.LayoutSlides.Add(sourceMaster, SlideLayoutType.Custom, "MyCustomLayout");

            // Save the target presentation
            string outputPath = "output.pptx";
            targetPresentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            sourcePresentation.Dispose();
            targetPresentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}