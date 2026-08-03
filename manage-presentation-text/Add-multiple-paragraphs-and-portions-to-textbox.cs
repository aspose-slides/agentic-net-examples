// -----------------------------------------------------------------------------
// Example: Add multiple paragraphs and portions to textbox using C#
//
// Description:
// Demonstrates how to add multiple paragraphs and portions to a textbox shape,
// assign text and distinct formatting to each portion, and save the result as a
// PPTX file using Aspose.Slides for .NET. The example illustrates the required
// presentation-processing steps for PowerPoint files in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multiple Paragraphs, Portions,
// Textbox, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding multiple paragraphs and portions to a textbox.
// - Build C# tools for detailed PowerPoint presentation processing.
// - Generate or transform PPTX files with custom text formatting in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string outputFile = "MultipleParagraphs_out.pptx";
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 300, 150);
        Aspose.Slides.ITextFrame tf = shape.TextFrame;
        Aspose.Slides.IParagraph para0 = tf.Paragraphs[0];
        Aspose.Slides.IPortion port01 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port02 = new Aspose.Slides.Portion();
        para0.Portions.Add(port01);
        para0.Portions.Add(port02);
        Aspose.Slides.IParagraph para1 = new Aspose.Slides.Paragraph();
        tf.Paragraphs.Add(para1);
        Aspose.Slides.IPortion port10 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port11 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port12 = new Aspose.Slides.Portion();
        para1.Portions.Add(port10);
        para1.Portions.Add(port11);
        para1.Portions.Add(port12);
        Aspose.Slides.IParagraph para2 = new Aspose.Slides.Paragraph();
        tf.Paragraphs.Add(para2);
        Aspose.Slides.IPortion port20 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port21 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port22 = new Aspose.Slides.Portion();
        para2.Portions.Add(port20);
        para2.Portions.Add(port21);
        para2.Portions.Add(port22);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Aspose.Slides.IPortion portion = tf.Paragraphs[i].Portions[j];
                portion.Text = "Portion" + i + "_" + j;
                if (j == 0)
                {
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                    portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                    portion.PortionFormat.FontHeight = 15;
                }
                else if (j == 1)
                {
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                    portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
                    portion.PortionFormat.FontHeight = 18;
                }
                else // j == 2
                {
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Green;
                    portion.PortionFormat.FontHeight = 20;
                }
            }
        }
        try
        {
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}
