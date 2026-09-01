// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Get effective rgb of schemecolor background1 using C#

//

// Description:

// Demonstrates how to get the effective RGB value of SchemeColor.Background1 using

// C# and Aspose.Slides for .NET. The example creates a presentation, applies a

// SchemeColor background fill to a shape, retrieves the resolved RGB color, and

// saves the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Effective, SchemeColor,

// Background1, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate retrieval of effective RGB values for scheme colors.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main()

    {

        // Create a new presentation

        using (Presentation pres = new Presentation())

        {

            // Add a rectangle shape

            IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

            // Set fill to use SchemeColor.Background1

            shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Background1;

            // Retrieve effective RGB color

            Color effectiveColor = shape.FillFormat.SolidFillColor.Color;

            Console.WriteLine("Effective RGB of SchemeColor.Background1: R={0}, G={1}, B={2}",

                effectiveColor.R, effectiveColor.G, effectiveColor.B);

            // Save presentation

            try

            {

                pres.Save("output.pptx", SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Format not supported

                Console.WriteLine("Error saving presentation: " + ex.Message);

            }

        }

    }

}

