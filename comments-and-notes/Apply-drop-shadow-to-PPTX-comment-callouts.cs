// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply drop shadow to PPTX comment callouts using C#

//

// Description:

// Demonstrates how to apply a drop shadow effect to modern comment callouts

// in a PowerPoint presentation using Aspose.Slides for .NET. The example

// creates a presentation, adds a comment with a callout shape, configures

// an outer shadow effect, and saves the result as a PPTX file. This pattern

// can be used to automate visual enhancements of comments in PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Drop, Shadow, Comment,

// Callout, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate applying drop shadow to PPTX comment callouts.

// - Build C# utilities for enhancing PowerPoint comment visuals.

// - Generate or transform PPTX files with styled comment callouts in .NET applications.

// - Validate and preview presentation comment formatting before publishing.

// -----------------------------------------------------------------------------

using System;

using System.Drawing;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        try

        {

            var presentation = new Aspose.Slides.Presentation();

            var slide = presentation.Slides[0];

            var author = presentation.CommentAuthors.AddAuthor("Author Name", "AN");

            var comment = author.Comments.AddModernComment(

                "This is a comment with shadow",

                slide,

                null,

                new PointF(100, 100),

                DateTime.Now);



            var commentShape = comment.Shape;

            if (commentShape != null)

            {

                commentShape.EffectFormat.EnableOuterShadowEffect();

                var outerShadow = commentShape.EffectFormat.OuterShadowEffect;

                outerShadow.BlurRadius = 5.0;

                outerShadow.Distance = 3.0;

                outerShadow.Direction = 45.0f;

                outerShadow.ShadowColor.Color = Color.Black;

            }



            var outputPath = "CommentShadow.pptx";

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

