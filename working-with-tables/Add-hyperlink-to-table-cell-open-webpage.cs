using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 150, 150, 150 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide at position (50, 50)
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Get a specific cell (row 0, column 0)
        Aspose.Slides.ICell cell = table[0, 0];

        // Add text to the cell
        cell.TextFrame.Text = "Click Here";

        // Create a hyperlink that points to an external web page
        Aspose.Slides.Hyperlink hyperlink = new Aspose.Slides.Hyperlink("https://www.example.com");

        // Assign the hyperlink to the text portion and set a tooltip
        cell.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = hyperlink;
        cell.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Open Example";

        // Save the presentation
        try
        {
            presentation.Save("TableHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save error
        }
    }
}