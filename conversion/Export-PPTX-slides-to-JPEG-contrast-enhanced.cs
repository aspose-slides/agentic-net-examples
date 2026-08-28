// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides to JPEG contrast enhanced using C#

//

// Description:

// Demonstrates how to export PPTX slides to JPEG images with automatic

// brightness and contrast enhancement applied to picture frames using

// Aspose.Slides for .NET. The example loads a presentation, enhances each

// picture frame on every slide, saves each slide as a JPEG file, and optionally

// saves the modified presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Contrast, 

// Brightness, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX slides to JPEG with contrast enhancement.

// - Build C# tools for PowerPoint image processing.

// - Generate or transform PPTX files in .NET applications.

// - Apply visual enhancements to slide images before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Effects;



namespace ExportSlidesWithContrast

{

    class Program

    {

        static void Main()

        {

            // Path to the source presentation

            string sourcePath = "input.pptx";



            // Verify that the source file exists

            if (!File.Exists(sourcePath))

            {

                Console.WriteLine("Source file not found: " + sourcePath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(sourcePath))

                {

                    // Iterate through each slide

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                    {

                        ISlide slide = presentation.Slides[slideIndex];



                        // Apply automatic brightness/contrast enhancement to all picture frames on the slide

                        foreach (IShape shape in slide.Shapes)

                        {

                            if (shape is IPictureFrame)

                            {

                                IPictureFrame pictureFrame = (IPictureFrame)shape;

                                IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;



                                // Add a brightness/contrast effect (values can be adjusted as needed)

                                imageTransform.AddBrightnessContrastEffect(0.2f, 0.2f);

                            }

                        }



                        // Export the slide to a JPEG image

                        IImage slideImage = slide.GetImage(1f, 1f);

                        string outputImagePath = $"slide_{slideIndex + 1}.jpg";

                        slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);

                    }



                    // Save the modified presentation (if needed)

                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Handle unsupported file format

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

