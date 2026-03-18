using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            var slide = presentation.Slides[0];

            // Define column widths and row heights for a simple table
            double[] columnWidths = { 150, 150, 150 };
            double[] rowHeights = { 50, 50 };

            // Add a table to the slide
            var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Get the first row of the table
            var firstRow = table.Rows[0];

            // Create a PortionFormat and set the desired font height
            var portionFormat = new Aspose.Slides.PortionFormat();
            portionFormat.FontHeight = 24f; // Set font height to 24 points

            // Apply the format to all cells in the first row
            firstRow.SetTextFormat(portionFormat);

            // Save the presentation
            presentation.Save("AdjustedFontHeight.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}