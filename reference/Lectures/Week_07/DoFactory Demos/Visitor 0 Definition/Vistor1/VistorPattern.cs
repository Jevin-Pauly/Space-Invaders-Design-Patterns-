using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Vistor1
{

    // The 'Visitor' abstract class
    abstract class Visitor
    {
        public abstract void VisitConcreteElementA( ConcreteElementA concreteElementA);
        public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }

    // A 'ConcreteVisitor' class
    class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Debug.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name);
        }
        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Debug.WriteLine("{0} visited by {1}",concreteElementB.GetType().Name, this.GetType().Name);
        }
    }

    // A 'ConcreteVisitor' class
    class ConcreteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Debug.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name);
        }
        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Debug.WriteLine("{0} visited by {1}",concreteElementB.GetType().Name, this.GetType().Name);
        }

    }

    // The 'Element' abstract class
    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    // A 'ConcreteElement' class
    class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {
        }
    }

    // A 'ConcreteElement' class
    class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {

        }

    }

    // The 'ObjectStructure' class
    class ObjectStructure
    {
        private List<Element> _elements = new List<Element>();

        public void Attach(Element element)
        {
            _elements.Add(element);

        }
        public void Detach(Element element)
        {
            _elements.Remove(element);
        }
        public void Accept(Visitor visitor)
        {
            foreach (Element element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
