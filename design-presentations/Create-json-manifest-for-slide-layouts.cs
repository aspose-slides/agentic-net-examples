// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create json manifest for slide layouts using C#

//

// Description:

// Demonstrates how to generate a JSON manifest describing each slide's layout

// type and its shapes (including shape type and text content) from a PowerPoint

// presentation using Aspose.Slides for .NET. The example loads a PPTX file,

// extracts layout and shape information, outputs the manifest to the console,

// and saves the presentation unchanged.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Json, Manifest, Slide, Layouts,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of JSON manifests for slide layout analysis.

// - Build tools for PowerPoint presentation inspection in .NET.

// - Integrate slide metadata extraction into CI pipelines or reporting systems.

// - Validate slide structures before publishing or further processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Collections.Generic;

using System.Text.Json;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        if (args.Length > 0)

        {

            inputPath = args[0];

        }



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        Presentation presentation = null;

        try

        {

            presentation = new Presentation(inputPath);

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            Console.WriteLine("Unsupported file format (PPTX).");

            return;

        }

        catch (Aspose.Slides.PptUnsupportedFormatException)

        {

            Console.WriteLine("Unsupported file format (PPT).");

            return;

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error loading presentation: " + ex.Message);

            return;

        }



        List<object> slidesInfo = new List<object>();

        for (int i = 0; i < presentation.Slides.Count; i++)

        {

            ISlide slide = presentation.Slides[i];

            ILayoutSlide layoutSlide = slide.LayoutSlide;

            SlideLayoutType layoutType = layoutSlide.LayoutType;



            List<object> shapesInfo = new List<object>();

            foreach (IShape shape in slide.Shapes)

            {

                string shapeTypeName = shape.GetType().Name;

                string text = string.Empty;

                IAutoShape autoShape = shape as IAutoShape;

                if (autoShape != null && autoShape.TextFrame != null)

                {

                    text = autoShape.TextFrame.Text;

                }

                shapesInfo.Add(new

                {

                    Type = shapeTypeName,

                    Text = text

                });

            }



            slidesInfo.Add(new

            {

                Index = i + 1,

                Layout = layoutType.ToString(),

                Shapes = shapesInfo

            });

        }



        string json = JsonSerializer.Serialize(slidesInfo, new JsonSerializerOptions { WriteIndented = true });

        Console.WriteLine(json);



        try

        {

            presentation.Save("output.pptx", SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error saving presentation: " + ex.Message);

        }

        finally

        {

            presentation.Dispose();

        }

    }

}

