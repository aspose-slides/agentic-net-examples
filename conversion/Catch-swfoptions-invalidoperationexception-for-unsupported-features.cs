using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string swfOutput = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");
            string pptxOutput = Path.Combine(Directory.GetCurrentDirectory(), "output_saved.pptx");

            // Check if input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found: " + inputFile);
                return;
            }

            // Check presentation protection (using provided rule)
            Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputFile);
            bool isWriteProtected = presentationInfo.IsWriteProtected == Aspose.Slides.NullableBool.True;
            bool isWriteProtectedByPassword = false;
            if (isWriteProtected)
            {
                // Replace "writePassword" with actual password if needed
                isWriteProtectedByPassword = presentationInfo.CheckWriteProtection("writePassword");
            }
            bool isPasswordProtected = presentationInfo.IsPasswordProtected;
            if (isPasswordProtected)
            {
                // Replace "openPassword" with actual password if needed
                bool isOpenPasswordCorrect = presentationInfo.CheckPassword("openPassword");
                if (!isOpenPasswordCorrect)
                {
                    Console.WriteLine("Incorrect open password.");
                    return;
                }
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
            {
                // Prepare SWF options
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                swfOptions.ViewerIncluded = true; // example setting

                try
                {
                    // Save as SWF with options
                    presentation.Save(swfOutput, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                    Console.WriteLine("Presentation saved as SWF: " + swfOutput);
                }
                catch (InvalidOperationException ex)
                {
                    // Handle unsupported features when saving to SWF
                    Console.WriteLine("Failed to save as SWF due to unsupported features: " + ex.Message);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Format not supported
                    // Comment: format not supported
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Format not supported
                    // Comment: format not supported
                }

                // Save the presentation before exit (as PPTX)
                presentation.Save(pptxOutput, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved as PPTX: " + pptxOutput);
            }
        }
    }
}