using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using TreeGP.GPTree;

namespace TreeGP
{
    class GP {
        public List<float> Inputs;
        public Random Rand;
        public List<Node> Population;
        public List<Type> FunctionSet;
        public List<Type> TerminalSet;
        public int PopSize;

        public GP(List<float> inputs, List<Type> functionSet, List<Type> terminalSet, int popSize, int initMaxDepth) {
            Inputs = inputs;
            FunctionSet = functionSet;
            TerminalSet = terminalSet;
            Rand = new Random();
            PopSize = popSize;
            Population = new List<Node>();
            FullInit(5);
        }

        public void FullInit(int maxDepth) {
            var fit = float.MinValue;
            while (Population.Count < PopSize) {
                var newNode = GenerateTree(maxDepth, true);
                Population.Add(newNode);

                var newfitness = Fitness(newNode);
                if (newfitness > fit) {
                    fit = newfitness;
                }
                //Console.WriteLine(newNode.Execute());
                //Console.WriteLine();
            }
            Console.WriteLine("Initial Population Generated. Best fitness: " + fit);
            Console.WriteLine(""+Node.CountChildren(Population[0]));
        }

        public Node GenerateTree(int maxDepth, bool full) {
            Type rootType;

            if (maxDepth == 0) {
                rootType = TerminalSet[Rand.Next(0, TerminalSet.Count)];
            }
            else {
                rootType = FunctionSet[Rand.Next(0, FunctionSet.Count)];
            }

            var root = (Node)Activator.CreateInstance(rootType, this);
            root.Children = new List<Node>();
            for (var i = 0; i < root.Arity(); i++) {
                root.Children.Add(GenerateTree(maxDepth - 1, full));
            }
            return root;
        }

        public float Fitness(Node program) {
            return -Math.Abs(program.Execute() - 1337);
        }
    }
}
