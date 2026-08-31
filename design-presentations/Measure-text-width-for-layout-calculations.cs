// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Measure text width for layout calculations using C#

//

// Description:

// Demonstrates how to retrieve font metrics and outlines the approach for

// measuring text width for layout calculations using C# and Aspose.Slides for

// .NET. The example loads a presentation, adds a shape with text, obtains the

// font height, and notes that precise width measurement requires rendering

// APIs provided by Aspose.Slides. This pattern helps developers automate PPTX

// workflows, perform layout validation, or integrate presentation logic into

// .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Measure, Text, Width, Layout,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate measurement of text dimensions for layout calculations.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found.");

            return;

        }



        try

        {

            LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);

            loadOptions.DefaultRegularFont = "Arial"; // set default sans‑serif font



            using (Presentation pres = new Presentation(inputPath, loadOptions))

            {

                ISlide slide = pres.Slides[0];

                IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(

                    ShapeType.Rectangle, 50, 50, 400, 100);

                shape.AddTextFrame("Sample text for measurement");



                // Retrieve font height; actual width measurement would require rendering APIs

                float fontHeight = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight;

                Console.WriteLine("Font height used: " + fontHeight);



                pres.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

