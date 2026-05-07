using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        TestSwfOptionsShowHiddenSlides();
    }

    static void TestSwfOptionsShowHiddenSlides()
    {
        string outputPath = "output.swf";

        // Delete existing file if present
        if (File.Exists(outputPath))
        {
            File.Delete(outputPath);
        }

        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Mark the first slide as hidden
                ISlide slide = presentation.Slides[0];
                slide.Hidden = true;

                // Configure SWF options
                SwfOptions options = new SwfOptions();
                options.ShowHiddenSlides = true;

                // Save as SWF; should not throw an exception
                presentation.Save(outputPath, SaveFormat.Swf, options);
            }

            Console.WriteLine("Test passed: No exception when ShowHiddenSlides is true.");
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported format: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Any other exception indicates test failure
            Console.WriteLine("Test failed: " + ex.GetType().FullName + " - " + ex.Message);
        }
        finally
        {
            // Clean up generated file
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }
    }
}