using System;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        // Create a new presentation (default constructor)
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Create SwfOptions instance
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            // Verify that ShowHiddenSlides defaults to false
            if (swfOptions.ShowHiddenSlides != false)
            {
                throw new InvalidOperationException("SwfOptions.ShowHiddenSlides default value is not false.");
            }

            // Save the presentation using the SwfOptions (required by lifecycle rule)
            try
            {
                presentation.Save("output.swf", Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported – handle accordingly
                // (In this context, Swf format is supported, so this block is for completeness)
            }
        }
    }
}