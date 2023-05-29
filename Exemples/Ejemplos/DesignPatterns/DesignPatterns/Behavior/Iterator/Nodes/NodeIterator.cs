using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.Iterator.Nodes
{
    internal class NodeIterator : IIterator
    {
        private readonly NodeCollection _nodes;
        private Node current;

        public NodeIterator(NodeCollection nodes)
        {
            _nodes = nodes;
            current = null;
        }

        public int GetCurrent()
        {
            return current.Value;
        }

        public bool MoveNext()
        {
            if (current is null)
            { 
                current = _nodes.GetFirst(); 
                return true; 
            }
            if (current.Right is not null) 
            { 
                current = current.Right; 
                while (true) 
                { 
                    if (current.Left is null) 
                    { 
                        break; 
                    } 
                    current = current.Left; 
                } 
                return true; 
            } 
            else 
            {
                var originalValue = current.Value; 
                while (true) 
                { 
                    if (current.Parent is not null) 
                    { 
                        current = current.Parent; 
                        if (current.Value > originalValue) 
                        { 
                            return true; 
                        } 
                    } 
                    else 
                    { 
                        return false; 
                    } 
                } 
            }
        }
    }
}
