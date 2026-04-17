using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSwfHiddenSlidesTest
{
    class Program
    {
        static void Main()
        {
            // Define file paths
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "test.pptx");
            var outputPathWithHidden = Path.Combine(Directory.GetCurrentDirectory(), "test_with_hidden.swf");
            var outputPathWithoutHidden = Path.Combine(Directory.GetCurrentDirectory(), "test_without_hidden.swf");

            // Create a presentation with one visible slide and one hidden slide
            using (var presentation = new Presentation())
            {
                // Ensure there is at least one slide (default slide already exists)
                var visibleSlide = presentation.Slides[0];

                // Add a hidden slide
                var hiddenSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                hiddenSlide.Hidden = true; // Mark slide as hidden

                // Save with ShowHiddenSlides = true
                var optionsWithHidden = new SwfOptions();
                optionsWithHidden.ShowHiddenSlides = true;
                presentation.Save(outputPathWithHidden, SaveFormat.Swf, optionsWithHidden);

                // Save with ShowHiddenSlides = false
                var optionsWithoutHidden = new SwfOptions();
                optionsWithoutHidden.ShowHiddenSlides = false;
                presentation.Save(outputPathWithoutHidden, SaveFormat.Swf, optionsWithoutHidden);
            }

            // Verify that both output files were created
            var existsWithHidden = File.Exists(outputPathWithHidden);
            var existsWithoutHidden = File.Exists(outputPathWithoutHidden);

            if (!existsWithHidden || !existsWithoutHidden)
            {
                Console.WriteLine("One or more output files were not created.");
                return;
            }

            // Compare file sizes to ensure hidden slide was included when option is true
            var sizeWithHidden = new FileInfo(outputPathWithHidden).Length;
            var sizeWithoutHidden = new FileInfo(outputPathWithoutHidden).Length;

            if (sizeWithHidden > sizeWithoutHidden)
            {
                Console.WriteLine("Test passed: Hidden slides are included when ShowHiddenSlides is true.");
            }
            else
            {
                Console.WriteLine("Test failed: Hidden slides were not included as expected.");
            }

            // Clean up generated files (optional)
            try
            {
                File.Delete(outputPathWithHidden);
                File.Delete(outputPathWithoutHidden);
                File.Delete(inputPath);
            }
            catch (Exception)
            {
                // Ignore cleanup errors
            }
        }
    }
}