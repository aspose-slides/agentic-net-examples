// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Change PPTX master slide background to navy using C#

//

// Description:

// Demonstrates how to change PPTX master slide background to navy using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Change, Pptx, Master, Slide, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate change PPTX master slide background to navy.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            Aspose.Slides.Presentation pres = null;

            try

            {

                if (File.Exists(inputPath))

                {

                    pres = new Aspose.Slides.Presentation(inputPath);

                }

                else

                {

                    pres = new Aspose.Slides.Presentation();

                }



                // Change the background of the first master slide to solid navy color

                if (pres.Masters.Count > 0)

                {

                    Aspose.Slides.IMasterSlide masterSlide = pres.Masters[0];

                    masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

                    masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.Navy;

                }



                // Save the presentation

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported

            }

            finally

            {

                if (pres != null)

                {

                    pres.Dispose();

                }

            }

        }

    }

}

