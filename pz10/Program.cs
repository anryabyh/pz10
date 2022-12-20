using System;

namespace pz10
{
    class Program
    {
        static void Main(string[] args)
        {
            Origin origin = new Origin();
            origin.OriginDouble(5.5);


            Client client = new Client();
            ITarget target = new Adapter();
            client.Request(target);



        }
    }

    // Адаптируемый класс
    public class Origin
    {
        public void OriginDouble(double dbl)
        {
            Console.WriteLine(dbl);
        }
        public void OriginInt(out int intt)
        {
            intt = 20;
            Console.WriteLine(intt);
            Console.ReadKey();
        }
        public void OriginChar(char ch)
        {
            Console.WriteLine(ch);
        }
    }
    //Адаптер
    public class Adapter : ITarget
    {
        private Origin origin = new Origin();
        
        public override void ClientDouble()
        {
            double dbl = 4.5;
            origin.OriginDouble(dbl);
        }
        public override void ClientInt()
        {
            int intt;
            origin.OriginInt(out intt);
            int intt2;
            origin.OriginInt(out intt2);

        }
        public override void ClientChar()
        {
            char ch = 'd';
            origin.OriginChar(ch);
            origin.OriginChar(ch);
            origin.OriginChar(ch);
            origin.OriginChar(ch);
            origin.OriginChar(ch);
        }
    }
    //класс, к которому надо адаптировать другой класс   
    public class ITarget
    {
        public virtual void ClientDouble()
        {
        }
        public virtual void ClientInt()
        {
        }
        public virtual void ClientChar()
        {
        }

    }
    public class Client
    {
        public void Request(ITarget itarget)
        {
            itarget.ClientDouble();
            itarget.ClientInt();
            itarget.ClientChar();
        }
    }
}
