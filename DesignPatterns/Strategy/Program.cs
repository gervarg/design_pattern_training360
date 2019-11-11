using System;
using System.Collections.Generic;

namespace Strategy
{
    // Summary:
    // Strategy pattern allows you to switch the algorithm or strategy based upon the situation.
    class Program
    {
        static void Main(string[] args)
        {
            TreeExample();

            SzjaExample();

            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1?view=netcore-3.0
            // new Dictionary<string, string>()
        }

        private static void TreeExample()
        {
            var tree = new TreeNode<int>(1)
            {
                Children = new List<TreeNode<int>>
                {
                    new TreeNode<int>(2)
                    {
                        Children = new List<TreeNode<int>>
                        {
                            new TreeNode<int>(3),
                            new TreeNode<int>(4),
                            new TreeNode<int>(5),
                        }
                    },
                    new TreeNode<int>(6),
                    new TreeNode<int>(7)
                    {
                        Children = new List<TreeNode<int>>
                        {
                            new TreeNode<int>(8),
                            new TreeNode<int>(9)
                            { 
                                Children = new List<TreeNode<int>>()
                                {
                                    new TreeNode<int>(10)
                                }
                            }
                        }
                    }
                }
            };

            Console.WriteLine(string.Join(',', tree.GetValues(new DepthIterator<int>())));
            Console.WriteLine(string.Join(',', tree.GetValues(new WidthIterator<int>())));
        }

        private static void SzjaExample()
        {
            var szjaKalkulátor2019 = new SzjaKalkulátor(new SzjaTörvény2019());
            Console.WriteLine(szjaKalkulátor2019.Kiszámít(450_000));

            var szjaKalkulátor2015 = new SzjaKalkulátor(new SzjaTörvény2015());
            Console.WriteLine(szjaKalkulátor2015.Kiszámít(450_000));

            var szjaKalkulátorKétkulcsos = new SzjaKalkulátor(new FiktívKétkulcsosSzjaTörvény());
            Console.WriteLine(szjaKalkulátorKétkulcsos.Kiszámít(450_000));
        }
    }
}
