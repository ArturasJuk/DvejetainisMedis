using System;
using System.Collections.Generic;
using System.Text;

namespace DvejetainisMedis
{
    class Tree
    {
        public Node Head { get; private set; }

        public void Add(int value)
        {
            if (null == Head)
                Head = new Node { value = value };
            else
                _Add(Head, value);
        }

        private void _Add(Node node, int value)
        {
            if (value < node.value)
            {
                if (null == node.left)
                    node.left = new Node { value = value };
                else
                    _Add(node.left, value);
            }
            else if (node.value < value)
            {
                if (null == node.right)
                    node.right = new Node { value = value };
                else
                    _Add(node.right, value);
            }
        }

        public void Traverse() =>
            _Traverse(Head);

        private void _Traverse(Node node)
        {
            if (null == node)
                return;
            else
            {
                _Traverse(node.left);
                Console.Write($"{node.value} ");
                _Traverse(node.right);
            }
        }

        public Node Find(int value) =>
            _Find(Head, value);

        private Node _Find(Node node, int value)
        {
            if (null == node)
                return null;
            else if (value == node.value)
                return node;
            else if (value < node.value)
                return _Find(node.left, value);
            else if (value > node.value)
                return _Find(node.right, value);
            return null;
        }

        public void Delete(int value)
        {
            if (null == Head)
                return;
            else if (value == Head.value)
            {
                var left = Head.left;
                var right = Head.right;
                Head = null;

                if (null != right)
                {
                    Head = right;
                    _AddNode(Head, left);
                }
                else if (null != left)
                    Head = left;
                return;
            }
            else
                _Delete(Head, value);
        }

        private void _Delete(Node parent, int value)
        {
            if ((null == parent) || (value < parent.value && parent.left == null) || (value > parent.value && parent.right == null))
                return;
            else if (parent.left != null && value == parent.left.value)
            {
                var left = parent.left.left;
                var right = parent.left.right;

                parent.left = null;
                _AddNode(Head, left);
                _AddNode(Head, right);
            }
            else if (parent.right != null && value == parent.right.value)
            {
                var left = parent.right.left;
                var right = parent.right.right;

                parent.right = null;
                _AddNode(Head, left);
                _AddNode(Head, right);
            }
            else if (value < parent.value)
                _Delete(parent.left, value);
            else if (value > parent.value)
                _Delete(parent.right, value);
            else
                return;
        }

        private void _AddNode(Node node, Node newNode)
        {
            if (null == newNode || node.value == newNode.value)
                return;
            else if (newNode.value < node.value)
            {
                if (null == node.left)
                    node.left = newNode;
                else
                    _AddNode(node.left, newNode);
            }
            else if (newNode.value > node.value)
            {
                if (null == node.right)
                    node.right = newNode;
                else
                    _AddNode(node.right, newNode);
            }
            else if (null == node)
                throw new Exception("Can not add values to null node");
        }
    }
}
