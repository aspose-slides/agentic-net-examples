using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace AsposeSlidesMathPortionFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a math shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 400, 100);

            // Get the first paragraph of the math shape
            IParagraph paragraph = mathShape.TextFrame.Paragraphs[0];

            // Add several MathPortion objects with different texts
            MathPortion portion1 = new MathPortion();
            portion1.Text = "x + y";
            paragraph.Portions.Add(portion1);

            MathPortion portion2 = new MathPortion();
            portion2.Text = "a - b";
            paragraph.Portions.Add(portion2);

            MathPortion portion3 = new MathPortion();
            portion3.Text = "x * z";
            paragraph.Portions.Add(portion3);

            // Use LINQ to select only MathPortion objects whose text contains the variable "x"
            List<MathPortion> filteredPortions = paragraph.Portions
                .OfType<MathPortion>()
                .Where(p => p.Text != null && p.Text.Contains("x"))
                .ToList();

            // Output the filtered portions' text to the console
            foreach (MathPortion mp in filteredPortions)
            {
                Console.WriteLine("Filtered MathPortion: " + mp.Text);
            }

            // Save the presentation
            presentation.Save("FilteredMathPortions.pptx", SaveFormat.Pptx);
        }
    }
}