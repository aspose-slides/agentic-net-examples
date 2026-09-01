// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply grayscale to PPTX and export PDF using C#

//

// Description:

// Demonstrates how to apply a grayscale effect to all picture frames in a PPTX

// presentation and export the result as a PDF using C# and Aspose.Slides for .NET.

// The example loads a presentation, iterates through slides and picture frames,

// applies the grayscale transformation, and saves the modified presentation as PDF.

// This pattern can be used to automate image processing in PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Grayscale, Export, 

// Presentation Processing, Office Automation, Image Transform

//

// Use Cases:

// - Automate applying grayscale to images in PPTX files and generate PDFs.

// - Build .NET tools for batch processing of PowerPoint presentations.

// - Integrate image effect workflows into existing C# applications.

// - Validate visual consistency of presentations before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Effects;



namespace AsposeSlidesExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Apply grayscale effect to all picture frames on each slide

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                    {

                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)

                        {

                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            if (shape is Aspose.Slides.IPictureFrame)

                            {

                                Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;

                                Aspose.Slides.Effects.IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

                                // Add grayscale effect

                                imageTransform.AddGrayScaleEffect();

                            }

                        }

                    }



                    // Save the modified presentation as PDF

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

