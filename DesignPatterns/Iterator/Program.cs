using System;
using System.Collections.Generic;

namespace Iterator
{
    // Summary:
    // Egy adatszerkezet elemeinek bejárását teszi lehetővé.
    // It presents a way to access the elements of an object without exposing the underlying presentation.
    // The iterator is used to traverse a container and access the container's elements. The iterator pattern decouples algorithms from containers.
    class Program
    {
        static void Main(string[] args)
        {
            //WebFarmExample();

            TreeExample();
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

            Console.WriteLine("Tree foreach:");
            foreach (var node in tree)
            {
                Console.WriteLine(node.Value);
            }
            Console.WriteLine();


            Console.WriteLine("Tree foreach2:");
            foreach (var node in tree)
            {
                Console.WriteLine(node.Value);
            }
            Console.WriteLine();


            var iterator = tree.GetEnumerator();

            Console.WriteLine("Tree iterator:");
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.Value);
            }
            Console.WriteLine();

            iterator.Reset();
            Console.WriteLine("Tree reset:");
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.Value);
            }
        }

        private static void WebFarmExample()
        {
            var webFarm = new WebFarm();
            webFarm.AddServer(new Server("server-1", "10.0.0.1", Server.Category.High));
            webFarm.AddServer(new Server("server-2", "10.0.0.2", Server.Category.Low));
            webFarm.AddServer(new Server("server-3", "10.0.0.3", Server.Category.Medium));
            webFarm.AddServer(new Server("server-4", "10.0.0.4", Server.Category.Medium));
            webFarm.AddServer(new Server("server-5", "10.0.0.5", Server.Category.Medium));

            // 1. Standard way
            foreach (Server server in webFarm)
            {
                Console.WriteLine(server);
            }
            Console.WriteLine();


            // 2. An alternate way.
            IEnumerator<Server> enumerator = webFarm.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine();

            
            // 3. Define multiple enumerator.
            IEnumerator<Server> customEnumerator = webFarm.GetCustomEnumerator();

            while (customEnumerator.MoveNext())
            {
                Console.WriteLine(customEnumerator.Current);
            }
            Console.WriteLine();
        }
    }
}
