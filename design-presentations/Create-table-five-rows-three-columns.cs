// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create table five rows three columns using C#

//

// Description:

// Demonstrates how to create a table with five rows and three columns using C#

// and Aspose.Slides for .NET. The example shows the required presentation‑processing

// steps for PowerPoint files and produces the requested output in a standalone

// console application. Developers can use this pattern to automate PPTX workflows,

// validate results, or integrate presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Five Rows, Three Columns,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of a table with five rows and three columns.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



namespace TableExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Create a new presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide

            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths (3 columns) and row heights (5 rows)

            double[] cols = new double[] { 100, 100, 100 };

            double[] rows = new double[] { 50, 50, 50, 50, 50 };

            // Add a table to the slide at position (50,50)

            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

            // Set solid red borders for each cell

            foreach (Aspose.Slides.IRow rowItem in table.Rows)

            {

                foreach (Aspose.Slides.ICell cell in rowItem)

                {

                    cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;

                    cell.CellFormat.BorderTop.Width = 5;

                    cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;

                    cell.CellFormat.BorderBottom.Width = 5;

                    cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;

                    cell.CellFormat.BorderLeft.Width = 5;

                    cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;

                    cell.CellFormat.BorderRight.Width = 5;

                }

            }

            // Save the presentation

            try

            {

                presentation.Save("TablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (System.Exception ex)

            {

                // Handle errors such as unsupported format

                System.Console.WriteLine("Error saving presentation: " + ex.Message);

            }

        }

    }

}

