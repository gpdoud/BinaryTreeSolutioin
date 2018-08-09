using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree {

	class Program {

		Leaf root = null;
		Leaf rebalRoot = null;

		void run() {
			Add(new Leaf { Value = 1 }, root);
			Add(new Leaf { Value = 2 }, root);
			Add(new Leaf { Value = 3 }, root);

			int sum = Accum(root);

			List<Leaf> leaves = new List<Leaf>();
			GetLeafs(root, leaves);
			Rebalance(leaves, rebalRoot);
		}
		IEnumerable<Leaf> Rebalance(IEnumerable<Leaf> leafs, Leaf subroot) {
			int median = (leafs.Count() + 1) / 2 - 1;
			subroot = leafs.ElementAt(median);
			List<Leaf> lower = leafs.Where(l => l.Value < subroot.Value).ToList();
			if(lower.Count > 0)
				Rebalance(lower, subroot.Left);
			List<Leaf> higher = leafs.Where(l => l.Value > subroot.Value).ToList();
			if(higher.Count > 0)
				Rebalance(higher, subroot.Right);
			
		}
		void GetLeafs(Leaf root, List<Leaf> leafs) {
			if (root.Left != null)
				GetLeafs(root.Left, leafs);
			leafs.Add(root);
			if (root.Right != null)
				GetLeafs(root.Right, leafs);
		}
		int Accum(Leaf leaf) {
			if (leaf == null)
				return 0;
			return leaf.Value + Accum(leaf.Left) + Accum(leaf.Right);
		}

		void Add(Leaf leaf, Leaf curr) {
			if (curr == null) {
				root = leaf;
				return;
			}
			if (leaf.Value < curr.Value) {
				if (curr.Left == null) {
					curr.Left = leaf;
					return;
				} else {
					Add(leaf, curr.Left);
				}
			} else {
				if (curr.Right == null) {
					curr.Right = leaf;
					return;
				} else {
					Add(leaf, curr.Right);
				}
			}
		}

		static void Main(string[] args) {
			(new Program()).run();
		}
	}
}
