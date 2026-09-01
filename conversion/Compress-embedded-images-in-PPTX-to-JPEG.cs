// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compress embedded images in PPTX to JPEG using C#

//

// Description:

// Demonstrates how to compress embedded images in a PPTX file to JPEG format

// using C# and Aspose.Slides for .NET. The example loads a presentation,

// iterates through picture frames, compresses each image (removing cropped

// areas) to a target resolution of 70 DPI, and saves the result as a new PPTX.

// This pattern can be used to reduce file size and convert images to JPEG

// within PowerPoint presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Compress, Embedded,

// Images, Presentation Processing, Office Automation

//

// Use Cases:

// - Reduce PPTX file size by compressing embedded images to JPEG.

// - Automate image optimization in PowerPoint presentations.

// - Integrate image compression into .NET applications handling PPTX files.

// - Prepare presentations for web publishing or distribution with smaller size.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CompressImagesExample

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

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Iterate through all slides and shapes to compress pictures

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                {

                    ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)

                    {

                        IShape shape = slide.Shapes[shapeIndex];

                        IPictureFrame pictureFrame = shape as IPictureFrame;

                        if (pictureFrame != null)

                        {

                            // Compress the image, delete cropped areas, target resolution 70 DPI

                            pictureFrame.PictureFormat.CompressImage(true, 70f);

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation saved successfully to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

