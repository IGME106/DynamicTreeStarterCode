using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynamicTreeStarterCode
{
	/// <summary>
	/// Represents a tree-centric data structure
	/// that can have data dynamically inserted, 
	/// and can be drawn as a literal "tree" on the screen
	/// </summary>
	class Tree : DrawableTree
	{
		// Already has an inherited root node field called "root"

		/// <summary>
		/// Creates a tree that can be drawn
		/// </summary>
		/// <param name="sb">The sprite batch used to draw</param>
		/// <param name="treeColor">The color of this tree</param>
		public Tree(SpriteBatch sb, Color treeColor)
			: base(sb, treeColor)
		{ }

		/// <summary>
		/// Public facing Insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		public void Insert(int data)
		{
            // *** Fill in this method ****************************************
            if (base.root == null)
            {
                base.root = new TreeNode(data);
            }
            else
            {
                Insert(data, base.root);
            }
		}

		/// <summary>
		/// Private recursive insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		/// <param name="node">The node to attempt to insert into</param>
		private void Insert(int data, TreeNode node)
		{
            // *** Fill in this method ****************************************
            if (data < node.Data)                                   // Test if the value of the provided data is less than the node data
            {
                if (node.Left != null)                              // If the left node is null, create one, alternatively recurse
                {
                    Insert(data, node.Left);
                }
                else
                {
                    node.Left = new TreeNode(data);
                }
            }
            else
            {
                if (node.Right != null)                             // If the right node is null, create one, alternatively recurse
                {
                    Insert(data, node.Right);
                }
                else
                {
                    node.Right = new TreeNode(data);
                }
            }            
		}
	}
}
