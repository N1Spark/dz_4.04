using System;
using System.Collections.Generic;

namespace dz_4._04
{
    public interface IElement
    {
        void Offer(IVisitor visitor);
    }
    public class Home : IElement
    {
        public void Offer(IVisitor visitor) => visitor.VisitHome(this);
        public string HomeString() { return "Home"; }
    }
    public class Factory : IElement
    {
        public void Offer(IVisitor visitor) => visitor.VisitFactory(this);
        public string FactoryString() { return "Factory"; }
    }
    public class Bank : IElement
    {
        public void Offer(IVisitor visitor) => visitor.VisitBank(this);
        public string BankString() { return "Bank"; }
    }
    public interface IVisitor
    {
        void VisitFactory(Factory element);
        void VisitHome(Home element);
        void VisitBank(Bank element);
    }
    class Medical_Insurance : IVisitor
    {
        public void VisitBank(Bank element) => Console.WriteLine(element.BankString() + " + Medical Insurance");
        public void VisitFactory(Factory element) => Console.WriteLine(element.FactoryString() + " + Medical Insurance");
        public void VisitHome(Home element) => Console.WriteLine(element.HomeString() + " + Medical Insurance");
    }
    class Robbery_Insurance : IVisitor
    {
        public void VisitBank(Bank element) => Console.WriteLine(element.BankString() + " + Robbery Insurance");
        public void VisitFactory(Factory element) => Console.WriteLine(element.FactoryString() + " + Robbery Insurance");
        public void VisitHome(Home element) => Console.WriteLine(element.HomeString() + " + Robbery Insurance");
    }
    class Fire_Insurance : IVisitor
    {
        public void VisitBank(Bank element) => Console.WriteLine(element.BankString() + " + Fire Insurance");
        public void VisitFactory(Factory element) => Console.WriteLine(element.FactoryString() + " + Fire Insurance");
        public void VisitHome(Home element) => Console.WriteLine(element.HomeString() + " + Fire Insurance");
    }
    public class Client
    {
        public static void ClientCode(List<IElement> components, IVisitor visitor)
        {
            foreach (var t in components)
                t.Offer(visitor);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IElement> elements = new List<IElement> { new Home(), new Bank(), new Factory() };
            IVisitor medical_Insurance = new Medical_Insurance();
            IVisitor robbery_Insurance = new Robbery_Insurance();
            IVisitor fire_Insurance = new Fire_Insurance();
            Client.ClientCode(elements, medical_Insurance);
            Client.ClientCode(elements, robbery_Insurance);
            Client.ClientCode(elements, fire_Insurance);
        }
    }
}
