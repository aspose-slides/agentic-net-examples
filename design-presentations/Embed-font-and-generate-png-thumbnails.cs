// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed fonts and generate PNG thumbnails using C#

//

// Description:

// Demonstrates how to embed all fonts used in PowerPoint presentations and

// generate PNG thumbnail images for each slide using Aspose.Slides for .NET.

// The example processes all PPTX files in a specified input folder, saves

// the font‑embedded presentations, and writes slide images to an output folder.

// This pattern can be used to automate batch presentation preparation and

// preview generation in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Embed Font, Generate Thumbnails,

// Batch Processing, Presentation Automation, Slide Images

//

// Use Cases:

// - Batch embed fonts into multiple PPTX files.

// - Generate PNG preview images for each slide in a presentation.

// - Build console tools for PowerPoint presentation processing.

// - Prepare presentations for distribution where font embedding is required.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace BatchFontEmbed

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputDirectory = "InputPresentations";

            string outputDirectory = "Output";



            // Verify input directory exists

            if (!System.IO.Directory.Exists(inputDirectory))

            {

                Console.WriteLine("Input directory does not exist: " + inputDirectory);

                return;

            }



            // Ensure output directory exists

            if (!System.IO.Directory.Exists(outputDirectory))

            {

                System.IO.Directory.CreateDirectory(outputDirectory);

            }



            // Process each PPTX file in the input directory

            string[] presentationFiles = System.IO.Directory.GetFiles(inputDirectory, "*.pptx");

            foreach (string presentationPath in presentationFiles)

            {

                try

                {

                    // Load the presentation

                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))

                    {

                        // Embed all fonts used in the presentation

                        Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

                        Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                        foreach (Aspose.Slides.IFontData font in allFonts)

                        {

                            bool isEmbedded = false;

                            foreach (Aspose.Slides.IFontData embedded in embeddedFonts)

                            {

                                if (embedded.FontName == font.FontName)

                                {

                                    isEmbedded = true;

                                    break;

                                }

                            }

                            if (!isEmbedded)

                            {

                                presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);

                            }

                        }



                        // Save the presentation with embedded fonts

                        string fileBaseName = System.IO.Path.GetFileNameWithoutExtension(presentationPath);

                        string savedPresentationPath = System.IO.Path.Combine(outputDirectory, fileBaseName + "_embedded.pptx");

                        presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);



                        // Generate PNG thumbnails for each slide

                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                        {

                            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                            using (Aspose.Slides.IImage slideImage = slide.GetImage())

                            {

                                string imagePath = System.IO.Path.Combine(outputDirectory, fileBaseName + "_slide_" + (slideIndex + 1) + ".png");

                                slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

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

                    Console.WriteLine("Error processing file " + presentationPath + ": " + ex.Message);

                }

            }

        }

    }

}

