using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianCycle
{
    class Program
    {
        static List<List<Node>> cycles = new List<List<Node>>();
        static Node a = new Node('A');
        static Node b = new Node('B');
        static Node c = new Node('C');
        static Node d = new Node('D');
        static Node e = new Node('E');
        static Node f = new Node('F');

        static void Main(string[] args)
        {
            GenerateGraph();
            a.Visited = true;
            List<Node> path = new List<Node>();
            path.Add(a);
            HamiltonianCycle(a, 1, path);

            foreach (List<Node> list in cycles)
            {
                foreach (Node item in list)
                {
                    Console.Write(item.Letter + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("There are {0} Hamiltonian cycles", cycles.Count);
        }

        public static void HamiltonianCycle(Node node, int level, List<Node> pathSoFar)
        {
            if (level == 6)
            {
                foreach (Node item in node.Neighbors)
                {
                    if (item == a)
                    {
                        List<Node> p = new List<Node>();
                        p.AddRange(pathSoFar);
                        cycles.Add(p);
                        break;
                    }
                }
                return;
            }
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                if (!node.Neighbors[i].Visited)
                {
                    node.Neighbors[i].Visited = true;
                    pathSoFar.Add(node.Neighbors[i]);
                    HamiltonianCycle(node.Neighbors[i], level + 1, pathSoFar);
                    pathSoFar.Remove(node.Neighbors[i]);

                    node.Neighbors[i].Visited = false;

                }
            }

        }

        private static void GenerateGraph()
        {
            a.Neighbors.Add(b);
            a.Neighbors.Add(c);
            a.Neighbors.Add(d);
            a.Neighbors.Add(f);

            b.Neighbors.Add(a);
            b.Neighbors.Add(c);
            b.Neighbors.Add(d);
            b.Neighbors.Add(e);

            c.Neighbors.Add(a);
            c.Neighbors.Add(b);
            c.Neighbors.Add(e);
            c.Neighbors.Add(f);

            d.Neighbors.Add(a);
            d.Neighbors.Add(b);
            d.Neighbors.Add(e);
            d.Neighbors.Add(f);

            e.Neighbors.Add(b);
            e.Neighbors.Add(c);
            e.Neighbors.Add(d);
            e.Neighbors.Add(f);

            f.Neighbors.Add(a);
            f.Neighbors.Add(c);
            f.Neighbors.Add(d);
            f.Neighbors.Add(e);

        }
    }
}
