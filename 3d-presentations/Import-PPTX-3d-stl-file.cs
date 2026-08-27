// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Import STL 3D model into a PPTX using C#

//

// Description:

// Demonstrates how to embed an STL 3D model file into a PowerPoint presentation

// as an OLE object using Aspose.Slides for .NET. The example creates a new

// presentation, adds the STL file as an OLE object covering the entire slide,

// disables the default icon representation, and saves the result as a PPTX file.

// This pattern can be used to automate the inclusion of 3D models in PowerPoint

// presentations within .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, STL, 3D model, Aspose.Slides for .NET, OLE object, 

// Presentation automation, Office Automation

//

// Use Cases:

// - Automate embedding STL 3D models into PowerPoint slides.

// - Build C# tools for creating or enhancing PPTX files with 3D content.

// - Integrate 3D model visualization into .NET presentation workflows.

// - Validate and process STL files for inclusion in Office documents.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.DOM.Ole;



class Program

{

    static void Main()

    {

        string stlPath = "model.stl";

        string outputPath = "output.pptx";



        if (!File.Exists(stlPath))

        {

            Console.WriteLine("STL file not found: " + stlPath);

            return;

        }



        try

        {

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            Aspose.Slides.ISlide slide = presentation.Slides[0];



            byte[] stlData = File.ReadAllBytes(stlPath);

            Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(stlData, "stl");



            Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(

                0,

                0,

                presentation.SlideSize.Size.Width,

                presentation.SlideSize.Size.Height,

                dataInfo);



            // Show the 3D object instead of an icon

            oleObjectFrame.IsObjectIcon = false;



            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle format not supported or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

