using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Enumerate all predefined slide size types
            foreach (SlideSizeType sizeType in (SlideSizeType[])Enum.GetValues(typeof(SlideSizeType)))
            {
                // Apply the slide size without scaling existing content
                presentation.SlideSize.SetSize(sizeType, SlideSizeScaleType.DoNotScale);

                // Retrieve the dimensions (width and height in points)
                System.Drawing.SizeF dimensions = presentation.SlideSize.Size;

                // Output the slide size type and its dimensions
                Console.WriteLine($"{sizeType}: Width = {dimensions.Width} pt, Height = {dimensions.Height} pt");
            }

            // Save the presentation before exiting
            presentation.Save("SlideSizes.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}