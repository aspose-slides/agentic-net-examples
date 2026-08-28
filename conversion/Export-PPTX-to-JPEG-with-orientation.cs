// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to JPEG with orientation using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX presentation to JPEG

// images using Aspose.Slides for .NET. The example loads a presentation,

// iterates through its slides, renders each slide to a full‑scale image,

// and saves the images as JPEG files. A placeholder is included for adding

// an EXIF orientation tag if required.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Orientation, 

// Slide Export, Image Processing, Presentation Automation

//

// Use Cases:

// - Automate conversion of PPTX slides to JPEG images.

// - Build C# utilities for PowerPoint slide extraction.

// - Integrate slide‑to‑image conversion into .NET applications.

// - Prepare images with correct orientation metadata for downstream use.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportSlidesToJpeg

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "presentation.pptx";



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

                    // Export each slide to JPEG

                    for (int index = 0; index < pres.Slides.Count; index++)

                    {

                        ISlide slide = pres.Slides[index];

                        // Get full‑scale image of the slide

                        using (IImage slideImage = slide.GetImage(1f, 1f))

                        {

                            string outputPath = $"slide_{index + 1}.jpg";

                            // Save as JPEG

                            slideImage.Save(outputPath, ImageFormat.Jpeg);

                            // TODO: Embed EXIF orientation tag if required

                        }

                    }



                    // Save the presentation (required before exit)

                    pres.Save("presentation_saved.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., network issues if URLs were used)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

