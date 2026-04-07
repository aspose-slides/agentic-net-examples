using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize SwfOptions
            SwfOptions swfOptions = new SwfOptions();

            // Verify that ViewerIncluded defaults to true
            if (swfOptions.ViewerIncluded != true)
            {
                Console.WriteLine("Test Failed: ViewerIncluded default is not true.");
            }
            else
            {
                Console.WriteLine("Test Passed: ViewerIncluded default is true.");
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected exceptions
            Console.WriteLine("Exception occurred: " + ex.Message);
        }
    }
}