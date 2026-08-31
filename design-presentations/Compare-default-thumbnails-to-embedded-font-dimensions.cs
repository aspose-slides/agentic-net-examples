// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare default thumbnails to embedded font dimensions using C#

//

// Description:

// Demonstrates how to generate slide thumbnails before and after embedding

// fonts, compare their dimensions, and save the presentation with embedded

// fonts using Aspose.Slides for .NET. The example shows the required

// presentation‑processing steps for PowerPoint files and produces the

// requested output in a standalone console application. Developers can use

// this pattern to automate PPTX workflows, validate results, or integrate

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compare, Default Thumbnails,

// Embedded Fonts, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate comparison of default thumbnails to embedded font dimensions.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideThumbnailComparison

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputRegularThumb = "thumb_regular.jpg";

            string outputEmbeddedThumb = "thumb_embedded.jpg";

            string outputPresentation = "output_embedded.pptx";



            // Check if input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Create rendering options with a default regular font

                    RenderingOptions renderOpts = new RenderingOptions

                    {

                        DefaultRegularFont = "Arial"

                    };



                    // Generate thumbnail using default regular font

                    using (IImage regularImage = pres.Slides[0].GetImage(renderOpts, 1f, 1f))

                    {

                        regularImage.Save(outputRegularThumb, ImageFormat.Jpeg);

                        int regularWidth = regularImage.Width;

                        int regularHeight = regularImage.Height;



                        // Add embedded fonts (using provided rule pattern)

                        IFontData[] allFonts = pres.FontsManager.GetFonts();

                        IFontData[] embeddedFonts = pres.FontsManager.GetEmbeddedFonts();

                        foreach (IFontData font in allFonts)

                        {

                            bool isEmbedded = false;

                            foreach (IFontData ef in embeddedFonts)

                            {

                                if (ef.Equals(font))

                                {

                                    isEmbedded = true;

                                    break;

                                }

                            }

                            if (!isEmbedded)

                            {

                                pres.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);

                            }

                        }



                        // Save presentation after embedding fonts

                        pres.Save(outputPresentation, SaveFormat.Pptx);



                        // Generate thumbnail after embedding fonts

                        using (IImage embeddedImage = pres.Slides[0].GetImage(renderOpts, 1f, 1f))

                        {

                            embeddedImage.Save(outputEmbeddedThumb, ImageFormat.Jpeg);

                            int embeddedWidth = embeddedImage.Width;

                            int embeddedHeight = embeddedImage.Height;



                            Console.WriteLine("Regular thumbnail size: {0}x{1}", regularWidth, regularHeight);

                            Console.WriteLine("Embedded thumbnail size: {0}x{1}", embeddedWidth, embeddedHeight);

                            if (regularWidth == embeddedWidth && regularHeight == embeddedHeight)

                            {

                                Console.WriteLine("Thumbnail dimensions are identical.");

                            }

                            else

                            {

                                Console.WriteLine("Thumbnail dimensions differ.");

                            }

                        }

                    }

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

            }

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

