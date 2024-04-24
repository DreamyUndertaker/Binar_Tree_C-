namespace BinarTree;

class Node
{
    public int Data;
    public Node Left, Right;

    public Node(int item)
    {
        Data = item;
        Left = Right = null;
    }
}

class BinaryTree
{
    Node root;

    BinaryTree()
    {
        root = null;
    }

    void Insert(int key)
    {
        root = InsertRec(root, key);
    }

    Node InsertRec(Node root, int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        if (key < root.Data)
            root.Left = InsertRec(root.Left, key);
        else if (key > root.Data)
            root.Right = InsertRec(root.Right, key);

        return root;
    }

    void Delete(int key)
    {
        root = DeleteRec(root, key);
    }

    Node DeleteRec(Node root, int key)
    {
        if (root == null) return root;

        if (key < root.Data)
            root.Left = DeleteRec(root.Left, key);
        else if (key > root.Data)
            root.Right = DeleteRec(root.Right, key);
        else
        {
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            root.Data = MinValue(root.Right);

            root.Right = DeleteRec(root.Right, root.Data);
        }

        return root;
    }

    int MinValue(Node root)
    {
        int minv = root.Data;
        while (root.Left != null)
        {
            minv = root.Left.Data;
            root = root.Left;
        }
        return minv;
    }

    void Inorder()
    {
        InorderRec(root);
    }

    void InorderRec(Node root)
    {
        if (root != null)
        {
            InorderRec(root.Left);
            Console.Write(root.Data + " ");
            InorderRec(root.Right);
        }
    }

    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        // Вставка элементов
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);

        Console.WriteLine("Binary Tree до удаления элементов : ");
        tree.Inorder();

        // Удаление элементов
        Console.WriteLine("\n\nУдаление 20");
        tree.Delete(20);
        Console.WriteLine("Binary Tree после удаления 20: ");
        tree.Inorder();

        Console.WriteLine("\n\nУдаление 30");
        tree.Delete(30);
        Console.WriteLine("Binary Tree после удаления 30: ");
        tree.Inorder();

        Console.WriteLine("\n\nУдаление 50");
        tree.Delete(50);
        Console.WriteLine("Binary Tree после удаления 50: ");
        tree.Inorder();
    }
}