// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load memory font and set body using C#

//

// Description:

// Demonstrates how to load a custom TrueType font from a file into memory and

// apply it to all text portions in a PowerPoint presentation using Aspose.Slides

// for .NET. The example reads the font file, registers it with the FontsLoader,

// iterates through each slide and shape, updates the Latin font of every text

// portion, and saves the modified presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Memory, Font, Body,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading a memory font and applying it to presentation text.

// - Build C# tools for PowerPoint presentation processing that require custom fonts.

// - Generate or transform PPTX files with specific typography in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";

        string fontPath = "customfont.ttf";

        string fontName = "CustomFont";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        if (!File.Exists(fontPath))

        {

            Console.WriteLine("Font file does not exist.");

            return;

        }



        try

        {

            byte[] fontData = File.ReadAllBytes(fontPath);

            Aspose.Slides.FontsLoader.LoadExternalFont(fontData);



            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            foreach (Aspose.Slides.ISlide slide in pres.Slides)

            {

                foreach (Aspose.Slides.IShape shape in slide.Shapes)

                {

                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                    if (autoShape != null && autoShape.TextFrame != null)

                    {

                        foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)

                        {

                            foreach (Aspose.Slides.IPortion portion in paragraph.Portions)

                            {

                                portion.PortionFormat.LatinFont = new Aspose.Slides.FontData(fontName);

                            }

                        }

                    }

                }

            }



            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

            Aspose.Slides.FontsLoader.ClearCache();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

