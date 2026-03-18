using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide1 = presentation.Slides[0];

                // Define column widths and row heights for the table
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 30, 30 };

                // Add a table to the first slide
                Aspose.Slides.ITable table1 = slide1.Shapes.AddTable(50, 50, columnWidths, rowHeights);
                // Apply a predefined table style
                table1.StylePreset = Aspose.Slides.TableStylePreset.MediumStyle2Accent1;

                // Add a second slide using the same layout as the first slide
                Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                // Add a table to the second slide
                Aspose.Slides.ITable table2 = slide2.Shapes.AddTable(50, 50, columnWidths, rowHeights);
                // Apply the same table style for consistent formatting
                table2.StylePreset = Aspose.Slides.TableStylePreset.MediumStyle2Accent1;

                // Save the presentation
                presentation.Save("StyledTablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}