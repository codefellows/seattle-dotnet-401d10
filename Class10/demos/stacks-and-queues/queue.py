class Queue:

    def __init__(self):
        self.front = None
        self.rear = None

    def enqueue(self, value):

        node = Node(value)

        # empty
        if not self.rear:
            self.rear = node
            self.front = node
        else:
            self.rear.next = node
            self.rear = node


    def dequeue(self):
        if not self.front:
            raise IndexError("Method not allowed on empty collection")

        temp = self.front

        self.front = self.front.next

        temp.next = None

        return temp.value

    def peek(self):
        if not self.front:
            raise IndexError("Method not allowed on empty collection")
        
        return self.front.value

    def is_empty(self):
        return self.front == None



class Node:
    def __init__(self, value, next_=None):
        self.value = value
        self.next = next_