using System;
using System.Collections.Generic;

namespace TreeGP.GPTree.Nodes
{
    class PDivNode : Node
    {
        public override float Execute() {
            var c0 = Children[0].Execute();
            var c1 = Children[1].Execute();
            if (Math.Abs(c1) > 0.00001) {
                return c0 / c1;
            }
            else {
                return 1;
            }
        }

        public override int Arity()
        {
            return 2;
        }

        public PDivNode(GP gp)
        {
            GP = gp;
        }

        public override Node Clone()
        {
            var root = new PDivNode(GP);
            root.Children = new List<Node>();
            for (var i = 0; i < Arity(); i++)
            {
                root.Children.Add(Children[i].Clone());
            }
            return root;
        }
    }
}
