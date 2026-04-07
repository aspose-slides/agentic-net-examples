using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string presentationPath = "TestPresentation.pptx";

            // Ensure any existing file is removed before creating a new one
            if (File.Exists(presentationPath))
            {
                File.Delete(presentationPath);
            }

            // Create a new presentation and save it
            using (Presentation presentation = new Presentation())
            {
                presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            // Verify the file exists before loading
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file was not created.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Get font substitution information
                    var substitutions = presentation.FontsManager.GetSubstitutions();

                    // Assert that the collection is empty when all fonts are available
                    if (substitutions.Any())
                    {
                        Console.WriteLine("Test failed: Expected no font substitutions, but some were found.");
                    }
                    else
                    {
                        Console.WriteLine("Test passed: No font substitutions returned as expected.");
                    }

                    // Save the presentation before exiting
                    presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}