// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set picture fill from stream with transparency using C#

//

// Description:

// Demonstrates how to set a picture fill for a slide background from a file

// stream and apply transparency using Aspose.Slides for .NET. The example

// loads an image, assigns it as the background fill of the first slide, and

// modifies its opacity via an image transform operation. The resulting

// presentation is saved as a PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Picture Fill, Stream, 

// Transparency, Image Transform, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting slide background images from streams with custom transparency.

// - Build .NET tools for PowerPoint presentation processing that require dynamic image fills.

// - Generate or transform PPTX files with picture backgrounds in server-side applications.

// - Validate presentation workflows involving image streams and visual effects.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Effects;



namespace SetPictureFillBackground

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the image file that will be used as picture fill

            string imagePath = "background.jpg";



            // Verify that the image file exists

            if (!File.Exists(imagePath))

            {

                Console.WriteLine("Image file not found: " + imagePath);

                return;

            }



            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                try

                {

                    // Load image from a file stream and add it to the presentation's image collection

                    using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))

                    {

                        // Keep the stream locked to avoid additional file access

                        IPPImage pictureImage = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);



                        // Configure the background of the first slide to use picture fill

                        ISlide slide = presentation.Slides[0];

                        slide.Background.Type = BackgroundType.OwnBackground;

                        slide.Background.FillFormat.FillType = FillType.Picture;

                        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;



                        // Assign the loaded image to the picture fill

                        slide.Background.FillFormat.PictureFillFormat.Picture.Image = pictureImage;



                        // Apply 30% opacity (70% transparency) using AlphaModulateFixed effect

                        IImageTransformOperationCollection transformOps = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

                        // Amount is a percentage (0.0f – 1.0f). 0.3f corresponds to 30% opacity.

                        transformOps.AddAlphaModulateFixedEffect(0.3f);

                    }



                    // Save the presentation

                    presentation.Save("output.pptx", SaveFormat.Pptx);

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine("The specified file format is not supported.");

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., I/O errors, Aspose.Slides errors)

                    Console.WriteLine("An error occurred: " + ex.Message);

                }

            }

        }

    }

}

