﻿using System.Collections.Generic;

namespace TreeGP.GPTree.Nodes
{
    class MinusNode : Node
    {
        public override float Execute() {
            return Children[0].Execute() - Children[1].Execute();
        }

        public override int Arity()
        {
            return 2;
        }

        public MinusNode(GP gp)
        {
            GP = gp;
        }

        public override Node Clone()
        {
            var root = new MinusNode(GP);
            root.Children = new List<Node>();
            for (var i = 0; i < Arity(); i++)
            {
                root.Children.Add(Children[i].Clone());
            }
            return root;
        }
    }
}
