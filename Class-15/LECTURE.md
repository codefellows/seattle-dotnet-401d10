# Class 10

## Trees

### Review: Linked List
  - A bunch of balloons attached at their ends.
  - Uni-directional flow.
    - information is connected one-way (next).
- made up of nodes
  - What is a node?
    - A Reference.
    - Value / Container for a value
    - Reference to something.
    - It also contains another reference to another node.
      - Recursive data structure.
- Head
  - The very first reference(node) that we need to "travserve".

```cs

class Node
{
  public int Value;
  public Node Next;
}

class List
{
  public void traversal(Node head)
  {
    public Node current = head;

    while(current != null)
    {
      Console.WriteLine(current.Value);
      current = current.Next;
    }
  }
}
```

## Tree Terminology
- Root: The Node on a tree that doesn't have in incoming node.
  - Think of this as the beginning of your tree.

- Edge / Branch: The connection between nodes, and there is only one incoming, and possibly multiple outgoing.
  - The 'link' / connection between the nodes.

- Properties of Tree Nodes
  - Left / Right: some outgoing reference to another node.
  - Typically left values, are less than right values.

- Leaf: A Node without any outgoing connections.
  - No Children

- Height: Maximum level at any node within the tree
  - Level: The number of edges from the root to a given node.
  - Path: A list of nodes, leading to a target node.
  
- Parent: A node with an outgoing edge.
- Child / children: A node /  nodes with an incoming edge.
- siblings: Nodes that share the same parent.

## Types of Binary Trees
- Binary Tree: a tree whose nodes can only have a left / right (only two references max);
  - k-ary: a tree with more than 2 nodes.

- Full Tree: all parent nodes have 2 children
- Complete: All levels are full, except the last. And all nodes are as far left as possible.
- Perfect: Has absolutely all levels filled.
- Balanced: The height of left and right subtrees of every node differ by no more than 1.

- Maximum number of node: We add 2^h(height) to our current tree with every added level.

## Recursion
- What is recursion?
  - Something coming up multiple times
  - A method that calls itself.
  - Something that is repeating within itself.

## Tree Demo

```js

class Node
{
  public Node Left;
  public Node Right;
  public int Value;
  public void display()
  {
    Console.WriteLine(Value);
  }
}

class BinarySearchTree
{
  public Node Root;

  public Node insert(Node root, int value)
  {
      if (root == null)
      {
        root = new Node()
        root.Value = value;
      }
      else if (v < root.Value)
      {
        root.Left = insert(root.Left, value);
      }
      else
      {
        root.Right = insert(root.Right, value);
      }

      this.Root = root;
      return this.Root;
  }

  public void traversal(Node root)
  {
    // Base case
    if (root == null) {
      return;
    }

    // *****  where we can do our Node.Value specific operations  
    root.display();
    // *****

    traversal(root.Left);
    traversal(root.Right);
    // if (root.left != null) {
    //   root.Left.display()
    // } else {
    //   root.Right.display()
    // }
  }
}

class Program
{
  static void Main()
  {
    BinarySearchTree Tree = new Tree();
    Tree.Root = new Node();
    Tree.Root.Value = 3;

    Tree.insert(Tree.Root, 4);
    Tree.insert(Tree.Root, 5);
    // Works, but is not programmatic, how can add things to this tree?
    // Tree.Root.Left = new Node();
    // Tree.Root.Left.Value = 4;
    // Tree.Root.Right.Value = 5;


  }
}

```