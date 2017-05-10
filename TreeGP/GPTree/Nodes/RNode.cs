using System.Collections.Generic;

namespace TreeGP.GPTree.Nodes
{
    class RNode : Node {
        private float _value;

        public override float Execute() {
            return _value;
        }
        
        public override int Arity()
        {
            return 0;
        }

        public RNode(GP gp)
        {
            GP = gp;
            _value = (float)GP.Rand.NextDouble();
        }

        public RNode(GP gp, float val) {
            GP = gp;
            _value = val;
        }

        public override Node Clone()
        {
            var root = new RNode(GP, _value);
            root.Children = new List<Node>();
            for (var i = 0; i < Arity(); i++)
            {
                root.Children.Add(Children[i].Clone());
            }
            return root;
        }
    }
}
