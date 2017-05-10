using System.Collections.Generic;

namespace TreeGP.GPTree
{
    abstract class Node {
        public abstract float Execute();
        public abstract int Arity();

        public abstract Node Clone();

        public GP GP;
        public List<Node> Children { get; set; }

        public static int CountChildren(Node node) {
            if (node.Arity() == 0) {
                return 1;
            }

            var tot = 1;
            for (int i = 0; i < node.Arity(); i++) {
                tot += CountChildren(node.Children[i]);
            }
            return tot;
        }

        public static Node Crossover(Node first, Node second) {
            var firstCount = CountChildren(first);
            var secondCount = CountChildren(second);

            var firstXO = first.GP.Rand.Next(0, firstCount);
            var secondXO = first.GP.Rand.Next(0, secondCount);


            return null;
        }
    }
}
