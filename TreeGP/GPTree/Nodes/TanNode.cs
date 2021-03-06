﻿using System;
using System.Collections.Generic;

namespace TreeGP.GPTree.Nodes
{
    class TanNode : Node
    {
        public override float Execute() {
            return (float)Math.Tan(Children[0].Execute());
        }

        public override int Arity()
        {
            return 1;
        }

        public TanNode(GP gp)
        {
            GP = gp;
        }

        public override Node Clone()
        {
            var root = new TanNode(GP);
            root.Children = new List<Node>();
            for (var i = 0; i < Arity(); i++)
            {
                root.Children.Add(Children[i].Clone());
            }
            return root;
        }
    }
}
