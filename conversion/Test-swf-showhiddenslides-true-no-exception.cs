using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfOptionsTest
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation in memory
            Presentation presentation = new Presentation();

            // Configure SWF options with ShowHiddenSlides set to true
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ShowHiddenSlides = true;

            // Use a memory stream to avoid file system dependencies
            MemoryStream outputStream = new MemoryStream();

            try
            {
                // Attempt to save the presentation as SWF with the configured options
                presentation.Save(outputStream, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                // If no exception is thrown, the test passes
                Console.WriteLine("Test passed: No exception thrown when ShowHiddenSlides is true.");
            }
            catch (Exception ex)
            {
                // If any exception occurs, the test fails
                Console.WriteLine("Test failed: Exception thrown - " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                outputStream.Dispose();
                presentation.Dispose();
            }
        }
    }
}