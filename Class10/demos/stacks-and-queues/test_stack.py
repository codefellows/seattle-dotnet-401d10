import pytest
from stack import Stack

def test_stack_instance():
    stack = Stack()

def test_is_empty():
    stack = Stack()
    actual = stack.is_empty()
    expected = True
    assert actual == expected

def test_is_empty_after_push():
    stack = Stack()
    stack.push("apples")
    actual = stack.is_empty()
    expected = False
    assert actual == expected

def test_peek_with_stuff():
    stack = Stack()
    stack.push("bananas")
    actual = stack.peek()
    expected = "bananas"
    assert actual == expected

def test_peek_when_empty():
    stack = Stack()

    with pytest.raises(IndexError):
        actual = stack.peek()
    
def test_pop_with_stuff():
    stack = Stack()
    stack.push("cucumbers")
    actual = stack.pop()
    expected = "cucumbers"
    assert actual == expected

def test_pop_empty():
    stack = Stack()

    with pytest.raises(IndexError):
        actual = stack.pop()
    