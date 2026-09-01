// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to ODP verify hyperlinks using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation to ODP format while

// verifying that hyperlink clicks are preserved using Aspose.Slides for .NET.

// The example loads a PPTX file, counts hyperlinks, saves as ODP, reloads the

// ODP file, recounts hyperlinks, and reports whether all hyperlinks survived

// the conversion.

//

// Keywords:

// C#, PowerPoint, PPTX, ODP, Aspose.Slides for .NET, Hyperlinks, Conversion,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to ODP while ensuring hyperlink integrity.

// - Automate validation of hyperlink preservation during format conversion.

// - Build .NET tools for batch processing of presentations with hyperlink checks.

// - Integrate presentation conversion and verification into CI pipelines.

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

        string outputPath = "output.odp";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            int hyperlinkCountBefore = 0;

            foreach (ISlide slide in presentation.Slides)

            {

                foreach (IShape shape in slide.Shapes)

                {

                    IAutoShape autoShape = shape as IAutoShape;

                    if (autoShape != null && autoShape.TextFrame != null)

                    {

                        foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)

                        {

                            foreach (IPortion portion in paragraph.Portions)

                            {

                                if (portion.PortionFormat.HyperlinkClick != null)

                                {

                                    hyperlinkCountBefore++;

                                }

                            }

                        }

                    }

                }

            }



            presentation.Save(outputPath, SaveFormat.Odp);



            Presentation odpPresentation = new Presentation(outputPath);

            int hyperlinkCountAfter = 0;

            foreach (ISlide slide in odpPresentation.Slides)

            {

                foreach (IShape shape in slide.Shapes)

                {

                    IAutoShape autoShape = shape as IAutoShape;

                    if (autoShape != null && autoShape.TextFrame != null)

                    {

                        foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)

                        {

                            foreach (IPortion portion in paragraph.Portions)

                            {

                                if (portion.PortionFormat.HyperlinkClick != null)

                                {

                                    hyperlinkCountAfter++;

                                }

                            }

                        }

                    }

                }

            }



            if (hyperlinkCountBefore == hyperlinkCountAfter && hyperlinkCountBefore > 0)

            {

                Console.WriteLine("All hyperlinks are preserved after conversion.");

            }

            else

            {

                Console.WriteLine("Hyperlink validation failed. Before: {0}, After: {1}", hyperlinkCountBefore, hyperlinkCountAfter);

            }



            presentation.Dispose();

            odpPresentation.Dispose();

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

