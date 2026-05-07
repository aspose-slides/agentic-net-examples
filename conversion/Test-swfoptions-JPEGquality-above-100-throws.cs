using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfOptionsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Create SwfOptions
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            bool exceptionThrown = false;
            try
            {
                // Set invalid JpegQuality (>100)
                swfOptions.JpegQuality = 101;

                // Attempt to save presentation (should throw)
                presentation.Save("output.swf", Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            }
            catch (ArgumentOutOfRangeException)
            {
                exceptionThrown = true;
                Console.WriteLine("Expected exception caught: JpegQuality out of range.");
            }
            catch (Exception ex)
            {
                // Unexpected exception
                Console.WriteLine("Unexpected exception: " + ex.Message);
            }
            finally
            {
                // Ensure presentation is saved if no exception (fallback)
                if (!exceptionThrown)
                {
                    // Save with default options
                    presentation.Save("output_default.swf", Aspose.Slides.Export.SaveFormat.Swf);
                }
                presentation.Dispose();
            }

            // Indicate test result
            if (exceptionThrown)
            {
                Console.WriteLine("Test passed.");
            }
            else
            {
                Console.WriteLine("Test failed: exception not thrown.");
            }
        }
    }
}