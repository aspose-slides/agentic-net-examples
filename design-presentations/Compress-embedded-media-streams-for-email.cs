// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compress embedded media streams for email using C#

//

// Description:

// Demonstrates how to compress images within a PowerPoint presentation to

// reduce file size for email transmission using C# and Aspose.Slides for .NET.

// The example loads a PPTX file, iterates through picture frames, applies

// compression, and saves the optimized presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Images, Media, 

// Presentation Processing, Email, Automation

//

// Use Cases:

// - Reduce PowerPoint file size before emailing.

// - Automate image compression in PPTX files.

// - Integrate presentation size optimization into .NET applications.

// - Prepare presentations for bandwidth‑limited environments.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CompressMediaExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output_compressed.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Iterate through all slides

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        ISlide slide = pres.Slides[i];



                        // Iterate through all shapes on the slide

                        for (int j = 0; j < slide.Shapes.Count; j++)

                        {

                            IShape shape = slide.Shapes[j];



                            // If the shape is a picture frame, compress its image

                            IPictureFrame pictureFrame = shape as IPictureFrame;

                            if (pictureFrame != null)

                            {

                                // Compress the picture using Dpi96 (minimum size) and delete cropped areas

                                pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi96);

                            }

                        }

                    }



                    // Save the optimized presentation

                    pres.Save(outputPath, SaveFormat.Pptx);

                }



                Console.WriteLine("Presentation compressed and saved to: " + outputPath);

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported for PPTX

                Console.WriteLine("The presentation format is not supported (PPTX).");

            }

            catch (PptUnsupportedFormatException)

            {

                // Format not supported for PPT

                Console.WriteLine("The presentation format is not supported (PPT).");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

