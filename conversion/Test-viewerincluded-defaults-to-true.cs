using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new SwfOptions instance
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            // Check the default value of ViewerIncluded
            bool viewerIncludedDefault = swfOptions.ViewerIncluded;

            if (viewerIncludedDefault)
            {
                Console.WriteLine("Test Passed: ViewerIncluded defaults to true.");
            }
            else
            {
                Console.WriteLine("Test Failed: ViewerIncluded default is not true.");
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected exceptions
            Console.WriteLine("Exception occurred: " + ex.Message);
        }
    }
}