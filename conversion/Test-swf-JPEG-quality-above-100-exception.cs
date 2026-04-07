using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create an empty presentation
        using (Presentation presentation = new Presentation())
        {
            // Initialize SWF export options
            SwfOptions swfOptions = new SwfOptions();

            try
            {
                // Set an invalid JPEG quality (greater than 100) – should throw ArgumentException
                swfOptions.JpegQuality = 150;
                Console.WriteLine("Test failed: No exception was thrown for invalid JpegQuality.");
            }
            catch (ArgumentException ex)
            {
                // Expected outcome
                Console.WriteLine("Caught expected exception - " + ex.Message);
            }
            catch (Exception ex)
            {
                // Any other exception is unexpected
                Console.WriteLine("Caught unexpected exception - " + ex.GetType().Name);
            }

            // Save the presentation (required before exit)
            string outputPath = "test_output.swf";
            try
            {
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported – comment for clarity
                // Format not supported
            }
        }
    }
}