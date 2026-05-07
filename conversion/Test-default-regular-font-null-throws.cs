using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                SwfOptions options = new SwfOptions();

                try
                {
                    // Attempt to set DefaultRegularFont to null, expecting an exception
                    options.DefaultRegularFont = null;
                    Console.WriteLine("No exception thrown when setting null.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException caught as expected.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected exception: " + ex.GetType().Name);
                }

                // Set a valid font and save the presentation as SWF
                options.DefaultRegularFont = "Arial";
                presentation.Save("output.swf", SaveFormat.Swf, options);
            }
        }
    }
}