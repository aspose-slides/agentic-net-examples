using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Add a new empty slide based on the first layout slide
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            // Add a rectangle shape to hold the overview text
            IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
            shape.AddTextFrame("Worksheet Formulas Overview\n\n" +
                               "• SUM(range) – Adds all numbers in a range.\n" +
                               "• AVERAGE(range) – Calculates the average.\n" +
                               "• COUNT(range) – Counts numeric entries.\n" +
                               "• IF(condition, trueVal, falseVal) – Conditional logic.\n" +
                               "• VLOOKUP(value, table, col, false) – Lookup.\n" +
                               "• CONCAT(text1, text2, ...) – Concatenates strings.");

            // Save the presentation
            string outputPath = "FormulaOverview.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}