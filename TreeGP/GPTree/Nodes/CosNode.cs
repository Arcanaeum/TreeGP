using System;
using System.Collections.Generic;

namespace TreeGP.GPTree.Nodes
{
    class CosNode : Node
    {
        public override float Execute() {
            return (float) Math.Cos(Children[0].Execute());
        }

        public override int Arity() {
            return 1;
        }

        public CosNode(GP gp) {
            GP = gp;
        }

        public override Node Clone() {
            var root = new CosNode(GP);
            root.Children = new List<Node>();
            for (var i = 0; i < Arity(); i++) {
                root.Children.Add(Children[i].Clone());
            }
            return root;
        }
    }
}
