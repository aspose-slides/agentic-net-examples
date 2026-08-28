// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Merge multiple TIFF files into multi TIFF using C#

//

// Description:

// Demonstrates how to merge multiple TIFF files into a single multi‑page TIFF

// using C# and Aspose.Slides for .NET. The example creates a temporary

// presentation, adds each TIFF image as a full‑size picture on separate slides,

// and then saves the presentation as a multi‑page TIFF document. This pattern

// can be used to automate image consolidation workflows, generate combined

// TIFFs from PowerPoint assets, or integrate TIFF processing into .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Merge, Multiple, TIFF, Files,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate merging of multiple TIFF images into a single multi‑page TIFF.

// - Build C# tools for PowerPoint presentation processing that output TIFFs.

// - Generate combined TIFF documents from slide images in .NET applications.

// - Validate and streamline image consolidation workflows before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



public class Program

{

    public static void Main(string[] args)

    {

        string[] inputFiles;

        if (args != null && args.Length > 0)

        {

            inputFiles = args;

        }

        else

        {

            inputFiles = new string[] { "input1.tiff", "input2.tiff", "input3.tiff" };

        }



        string outputFile = "merged_output.tiff";



        try

        {

            // Verify that all input files exist

            foreach (string filePath in inputFiles)

            {

                if (!File.Exists(filePath))

                {

                    Console.WriteLine("File not found: " + filePath);

                    return;

                }

            }



            // Create a new presentation

            Presentation presentation = new Presentation();



            // Ensure there is at least one layout slide to use

            if (presentation.LayoutSlides.Count == 0)

            {

                Console.WriteLine("No layout slides available.");

                presentation.Dispose();

                return;

            }



            // Add each TIFF image as a separate slide

            foreach (string filePath in inputFiles)

            {

                byte[] imageData = File.ReadAllBytes(filePath);

                IPPImage image = presentation.Images.AddImage(imageData);

                ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                slide.Shapes.AddPictureFrame(

                    ShapeType.Rectangle,

                    0,

                    0,

                    presentation.SlideSize.Size.Width,

                    presentation.SlideSize.Size.Height,

                    image);

            }



            // Prepare TIFF save options (default options are sufficient for multi‑page TIFF)

            TiffOptions tiffOptions = new TiffOptions();



            // Save the presentation as a multi‑page TIFF document

            presentation.Save(outputFile, SaveFormat.Tiff, tiffOptions);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

