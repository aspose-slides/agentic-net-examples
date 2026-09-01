// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply picture fill tiled to all slides using C#

//

// Description:

// Demonstrates how to apply a tiled picture fill as the background for all

// slides in a presentation using C# and Aspose.Slides for .NET. The example

// creates a new presentation, loads a background image, sets the picture fill

// mode to Tile for each slide, and saves the result as a PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Picture, Fill, Tiled,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate applying a tiled picture background to every slide.

// - Build C# utilities for PowerPoint presentation styling.

// - Generate or modify PPTX files with custom tiled backgrounds in .NET

//   applications.

// - Validate background fill settings before publishing presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideBackgroundTileExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define data directory and ensure it exists

            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");

            if (!Directory.Exists(dataDir))

            {

                Directory.CreateDirectory(dataDir);

            }



            // Define image path for background

            string imagePath = Path.Combine(dataDir, "background.jpg");



            // Check if the image file exists

            if (!File.Exists(imagePath))

            {

                Console.WriteLine("Image file not found: " + imagePath);

                return;

            }



            // Create a new presentation

            Presentation pres = new Presentation();



            try

            {

                // Load image and add to presentation's image collection

                IImage img = Images.FromFile(imagePath);

                IPPImage ppImg = pres.Images.AddImage(img);



                // Apply tiled picture fill to each slide background

                foreach (ISlide slide in pres.Slides)

                {

                    slide.Background.Type = BackgroundType.OwnBackground;

                    slide.Background.FillFormat.FillType = FillType.Picture;

                    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

                    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImg;

                }



                // Save the presentation

                string outPath = Path.Combine(dataDir, "TiledBackgroundPresentation.pptx");

                pres.Save(outPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other exceptions

                Console.WriteLine("An error occurred: " + ex.Message);

            }

            finally

            {

                // Ensure resources are released

                pres.Dispose();

            }

        }

    }

}

