// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply grayscale effect to picture shapes using C#

//

// Description:

// Demonstrates how to apply a grayscale effect to picture shapes within a

// PowerPoint presentation using C# and Aspose.Slides for .NET. The example

// loads an existing PPTX file, iterates through its slides and picture frames,

// adds a grayscale image transform, and saves the modified presentation.

// This pattern can be used to automate PPTX workflows, validate visual

// transformations, or integrate presentation processing into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Grayscale, Effect,

// Picture, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate applying a grayscale effect to picture shapes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace GrayscalePresentation

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Iterate through all slides

                foreach (ISlide slide in presentation.Slides)

                {

                    // Iterate through all shapes on the slide

                    foreach (IShape shape in slide.Shapes)

                    {

                        // Process only picture frames (image shapes)

                        IPictureFrame pictureFrame = shape as IPictureFrame;

                        if (pictureFrame != null)

                        {

                            // Get the image transform collection for the picture

                            Aspose.Slides.Effects.IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;



                            // Add a grayscale effect to the image

                            imageTransform.AddGrayScaleEffect();

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle exceptions (e.g., unsupported format)

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

