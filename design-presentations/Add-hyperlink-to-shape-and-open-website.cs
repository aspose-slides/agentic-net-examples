// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add hyperlink to shape and open website using C#

//

// Description:

// Demonstrates how to add a hyperlink to a shape and open a website using C#

// and Aspose.Slides for .NET. The example creates a presentation, inserts a

// rectangle shape with text, assigns an external hyperlink to the shape, and

// saves the presentation as a PPTX file. This pattern can be used to automate

// PowerPoint workflows that require interactive elements.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Shape, Open,

// Website, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding hyperlinks to shapes that open external websites.

// - Build C# tools for PowerPoint presentation processing with interactive

//   elements.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Presentation presentation = new Presentation();



        // Add a rectangle shape to the first slide

        IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(

            ShapeType.Rectangle, 100, 100, 200, 50);



        // Add text to the shape

        shape.AddTextFrame("Click here");



        // Set an external hyperlink that opens when the shape is clicked

        try

        {

            shape.HyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

        }

        catch (Exception ex)

        {

            // Handle any exception that occurs while setting the hyperlink

            Console.WriteLine("Error setting hyperlink: " + ex.Message);

        }



        // Save the presentation

        try

        {

            presentation.Save("HyperlinkDemo.pptx", SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Handle format not supported or other save errors

            Console.WriteLine("Error saving presentation: " + ex.Message);

        }



        // Dispose the presentation object

        presentation.Dispose();

    }

}

