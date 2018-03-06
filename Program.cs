using System;

namespace DoFactory.GangOfFour.Chain.RealWorld

{

    class MainApp

    {

        static void Main()

        {

            //Instancio los manejadores concretos

            Approver larry = new Director();

            Approver sam = new VicePresident();

            Approver tammy = new President();

            //Especifico sus sucesores

            larry.SetSuccessor(sam);

            sam.SetSuccessor(tammy);

            //Genero ordenes de compra para que procesen los manejadores

            Purchase p = new Purchase(2034, 350.00, "Assets");

            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");

            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");

            larry.ProcessRequest(p);

            Console.ReadKey();

        }

    }

    //La clase abstracta Manejador

    abstract class Approver

    {

        protected Approver successor;

        public void SetSuccessor(Approver successor)

        {

            this.successor = successor;

        }

        public abstract void ProcessRequest(Purchase purchase);

    }

    //La clase ManejadorConcreto1

    class Director : Approver

    {

        public override void ProcessRequest(Purchase purchase)

        {

            if (purchase.Amount < 10000.0)

            {

                Console.WriteLine("{0} approved request# {1}",

                  this.GetType().Name, purchase.Number);

            }

            else if (successor != null)

            {

                successor.ProcessRequest(purchase);

            }

        }

    }

    //La clase ManejadorConcreto2

    class VicePresident : Approver

    {

        public override void ProcessRequest(Purchase purchase)

        {

            if (purchase.Amount < 25000.0)

            {

                Console.WriteLine("{0} approved request# {1}",

                  this.GetType().Name, purchase.Number);

            }

            else if (successor != null)

            {

                successor.ProcessRequest(purchase);

            }

        }

    }

    //La clase ManejadorConcreto3

    class President : Approver

    {

        public override void ProcessRequest(Purchase purchase)

        {

            if (purchase.Amount < 100000.0)

            {

                Console.WriteLine("{0} approved request# {1}",

                  this.GetType().Name, purchase.Number);

            }

            else

            {

                Console.WriteLine(

                  "Request# {0} requires an executive meeting!",

                  purchase.Number);

            }

        }

    }

    class Purchase

    {

        private int _number;

        private double _amount;

        private string _purpose;

        public Purchase(int number, double amount, string purpose)

        {

            this._number = number;

            this._amount = amount;

            this._purpose = purpose;

        }

        public int Number

        {

            get { return _number; }

            set { _number = value; }

        }

        public double Amount

        {

            get { return _amount; }

            set { _amount = value; }

        }

        public string Purpose

        {

            get { return _purpose; }

            set { _purpose = value; }

        }

    }

}
