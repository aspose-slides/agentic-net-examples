using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfOptionsTests
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation instance
            Presentation presentation = new Presentation();

            // Instantiate SwfOptions
            SwfOptions swfOptions = new SwfOptions();

            // Verify that ShowHiddenSlides defaults to false
            if (swfOptions.ShowHiddenSlides != false)
            {
                throw new Exception("SwfOptions.ShowHiddenSlides default value is not false.");
            }

            // Define output file path
            string outputPath = "test_output.swf";

            // Attempt to save the presentation using SwfOptions
            try
            {
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }

            // Clean up the generated file if it exists
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }
    }
}