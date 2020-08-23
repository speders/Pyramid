using System;

namespace Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] data =
            {
                new[] {215},
                new[] {192, 124},
                new[] {117, 269, 442},
                new[] {218, 836, 347, 235},
                new[] {320, 805, 522, 417, 345},
                new[] { 229, 601, 728, 835, 133, 124 },
                new[] { 248, 202, 277, 433, 207, 263, 257 },
                new[] { 359, 464, 504, 528, 516, 716, 871, 182 },
                new[] { 461, 441, 426, 656, 863, 560, 380, 171, 923 },
                new[] { 381, 348, 573, 533, 448, 632, 387, 176, 975, 449 },
                new[] { 223, 711, 445, 645, 245, 543, 931, 532, 937, 541, 444 },
                new[] { 330, 131, 333, 928, 376, 733, 017, 778, 839, 168, 197, 197  },
                new[] { 131, 171, 522, 137, 217, 224, 291, 413, 528, 520, 227, 229, 928  },
                new[] { 223, 626, 034, 683, 839, 052, 627, 310, 713, 999, 629, 817, 410, 121  },
                new[] { 924, 622, 911, 233, 325, 139, 721, 218, 253, 223, 107, 233, 230, 124, 233  }
            };

            var pyramidCruncher = new PyramidCruncher();
            if (pyramidCruncher.Crunch(data))
            {
                Console.WriteLine($"Found {pyramidCruncher.FoundPaths.Count}:");
                foreach (var foundPath in pyramidCruncher.FoundPaths)
                {
                    Console.WriteLine($"Total: {foundPath.Total}, Path: {foundPath.Path}");
                }

                Console.WriteLine("\nMax");
                Console.WriteLine($"Total: {pyramidCruncher.MaxValue}, Path: {pyramidCruncher.MaxPath}");
            }
            else
            {
                Console.WriteLine("No path found");
            }

            Console.ReadLine();
        }
    }
}
