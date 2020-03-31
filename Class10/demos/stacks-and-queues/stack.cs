public class Stack<String>
{

    private Node top = null;

    public Stack()
    {
        // initialize as needed
    }

    public Null push(String value)
    {
        Node oldTop = top;
        top = new Node(value);
        top.next = oldTop;
    }

    public bool isEmpty()
    {
        return top == null;
    }

    public string peek()
    {

        // raise exception if empty

        return top.value;
    }

    public string pop()
    {

        // raise exception if empty

        Node oldTop = top;

        top = top.next;

        oldTop.next = null;

        return oldTop.value;
    }

}

public class Node
{
    public Object value;
    public Node next;
}
