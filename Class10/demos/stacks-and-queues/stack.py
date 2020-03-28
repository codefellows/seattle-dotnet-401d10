class Stack:
    
    def __init__(self):
        self.top = None


    def is_empty(self):
        return self.top == None

    def push(self, value):
        old_top = self.top
        self.top = Node(value)
        self.top.next = old_top

    def peek(self):

        if not self.top:
            raise IndexError("Empty Stack")

        return self.top.value

    def pop(self):

        if not self.top:
            raise IndexError("Empty Stack")
        
        current_top = self.top

        self.top = self.top.next

        return current_top.value


class Node:
    def __init__(self, value, next_=None):
        self.value = value
        self.next = next_

    