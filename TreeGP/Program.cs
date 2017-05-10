using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TreeGP.GPTree.Nodes;

namespace TreeGP
{
    class Program
    {
        static void Main(string[] args) {
            var functionSet = new List<Type> {typeof(CosNode), typeof(MinusNode), typeof(MultiplyNode), typeof(PDivNode), typeof(PlusNode), typeof(SinNode), typeof(TanNode)};
            var terminalSet = new List<Type> {typeof(RNode)};

            var gp = new GP(null, functionSet, terminalSet, 1000, 5);
        }
    }
}