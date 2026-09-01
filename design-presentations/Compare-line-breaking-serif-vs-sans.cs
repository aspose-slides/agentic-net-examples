// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare line breaking serif vs sans using C#

//

// Description:

// Demonstrates how to compare line breaking behavior of serif and sans‑serif

// fonts in a PowerPoint presentation using C# and Aspose.Slides for .NET.

// The example adds a rectangle with long text, saves the presentation twice

// with different default regular fonts (Times New Roman and Arial) and

// produces two output files for visual comparison.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compare, Line Breaking, Serif,

// Sans‑Serif, Font Impact, Presentation Processing, Office Automation

//

// Use Cases:

// - Visual comparison of line breaking between serif and sans‑serif fonts.

// - Automated generation of test presentations to evaluate typography.

// - Integration of font‑impact analysis into .NET PowerPoint workflows.

// - Validation of default font settings in presentation automation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontImpactDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define file paths

            string inputPath = "input.pptx";

            string outputSerifPath = "output_serif.pptx";

            string outputSansPath = "output_sans.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Add a rectangle shape with long text to observe line breaking

                ISlide slide = pres.Slides[0];

                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 200);

                shape.FillFormat.FillType = FillType.NoFill;

                ITextFrame tf = shape.TextFrame;

                tf.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";



                // Create rendering options and set default regular font to a serif font

                RenderingOptions renderingOpts = new RenderingOptions();

                renderingOpts.DefaultRegularFont = "Times New Roman";



                // Save presentation with serif default font

                pres.Save(outputSerifPath, SaveFormat.Pptx, renderingOpts);



                // Change default regular font to a sans‑serif font

                renderingOpts.DefaultRegularFont = "Arial";



                // Save presentation with sans‑serif default font

                pres.Save(outputSansPath, SaveFormat.Pptx, renderingOpts);



                // Dispose the presentation

                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Handle unsupported format scenario here

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

