// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set tiled image background for all slides using C#

//

// Description:

// Demonstrates how to set a tiled image as the background for all slides using

// C# and Aspose.Slides for .NET. The example loads (or creates) a presentation,

// adds a tile image to the presentation's image collection, applies a tiled

// picture fill to each slide's background, and saves the result as a PPTX file.

// This pattern can be used to automate PowerPoint background styling in .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Tiled, Image, Background,

// Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting a tiled image background for all slides.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files with custom tiled backgrounds in .NET.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideBackgroundTiledImage

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "tileImage.jpg");



            // Ensure the tile image exists

            if (!File.Exists(imagePath))

            {

                Console.WriteLine("Tile image not found: " + imagePath);

                return;

            }



            Presentation pres = null;



            try

            {

                // Load existing presentation if it exists, otherwise create a new one

                if (File.Exists(inputPath))

                {

                    pres = new Presentation(inputPath);

                }

                else

                {

                    pres = new Presentation();

                }

            }

            catch (Exception ex)

            {

                // Handle unsupported format exception

                // Format not supported

                Console.WriteLine("Error loading presentation: " + ex.Message);

                return;

            }



            // Load the image and add it to the presentation's image collection

            IImage img = Images.FromFile(imagePath);

            IPPImage ppImg = pres.Images.AddImage(img);



            // Apply tiled picture fill to each slide's background

            foreach (ISlide slide in pres.Slides)

            {

                // Set background to own background

                slide.Background.Type = BackgroundType.OwnBackground;



                // Set fill type to picture

                slide.Background.FillFormat.FillType = FillType.Picture;



                // Configure picture fill format

                IPictureFillFormat picFill = slide.Background.FillFormat.PictureFillFormat;

                picFill.Picture.Image = ppImg;

                picFill.PictureFillMode = PictureFillMode.Tile;

                // Optional: set tile alignment, scale, etc.

                picFill.TileAlignment = RectangleAlignment.TopLeft;

            }



            // Save the presentation

            try

            {

                pres.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle save errors (e.g., unsupported format)

                // Format not supported

                Console.WriteLine("Error saving presentation: " + ex.Message);

            }

        }

    }

}

