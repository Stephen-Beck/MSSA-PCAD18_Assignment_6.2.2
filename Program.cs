/*
Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
You must write an algorithm that runs in O(n) time and without using the division operation.

    Example 1:
        Input: nums = [1,2,3,4]
        Output: [24,12,8,6]

    Example 2:
        Input: nums = [-1,1,0,-3,3]
        Output: [0,0,9,0,0]
*/

namespace Assignment_6._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            Console.WriteLine($" Input: [{String.Join(",", nums)}]");
            int[] productArray = ArrayProduct(nums);
            Console.WriteLine($"Output: [{String.Join(",", productArray)}]\n");

            nums = new int[] { -1, 1, 0, -3, 3 };
            Console.WriteLine($" Input: [{String.Join(",", nums)}]");
            productArray = ArrayProduct(nums);
            Console.WriteLine($"Output: [{String.Join(",", productArray)}]\n");
        }

        static int[] ArrayProduct(int[] array)
        {
            #region Final Final Attempt (was able to remove the if statement)
            // Product array after index i
            int[] productArray = new int[array.Length];
            int product = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                productArray[i] = product;
                product *= array[i];
            }

            // While iterating through the array, calculate the "before" product and multiply it w/"after" into the result array
            product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                productArray[i] *= product;
                product *= array[i];
            }
            return productArray; 
            #endregion

            #region Final Attempt (refactored and removed one array)
            // Product array after index i
            productArray = new int[array.Length];
            product = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (i != array.Length - 1) product *= array[i + 1];

                productArray[i] = product;
            }

            // While iterating through the array, calculate the "before" product and multiply it w/"after" into the result array
            product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0) product *= array[i - 1];

                productArray[i] *= product;
            }
            return productArray;
            #endregion

            #region Second Attempt (had to look up the idea, but did not look up code)
            // Product array before index i
            int[] beforeArray = new int[array.Length];
            product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0) product *= array[i - 1];

                beforeArray[i] = product;
            }
            //Console.WriteLine(String.Join(",", beforeArray));

            // Product array after index i
            int[] afterArray = new int[array.Length];
            product = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (i != array.Length - 1) product *= array[i + 1];

                afterArray[i] = product;
            }
            //Console.WriteLine(String.Join(",", afterArray));

            // Multiple before/after arrays together
            for (int i = 0; i < array.Length; i++)
            {
                productArray[i] = beforeArray[i] * afterArray[i];
            }
            return productArray;
            #endregion

            #region First Attempt (nested loop)
            for (int i = 0; i < array.Length; i++)
            {
                product = 1;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i != j)
                    {
                        product *= array[j];
                    }
                }
                productArray[i] = product;
            }
            return productArray;
            #endregion
        }
    }
}
