namespace SOLIDPrinciple._4_InterfaceSegregationPrinciple
{
    /*I – Interface Segregation Principle (ISP)
    Clients should not be forced to depend on interfaces they do not use.

    This principle avoids creating large, general-purpose interfaces and instead divides them into smaller,
    more specific interfaces that are tailored to the exact needs of implementing classes.*/

    /* Bad Example */
    public interface IPrinter
    {
        void Print();
        void Scan();
        void Fax();
    }
    public class MultiFunctionPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
        public void Scan()
        {
            Console.WriteLine("Scanning...");
        }
        public void Fax()
        {
            Console.WriteLine("Faxing...");
        }
    }
    public class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
        public void Scan()
        {
            throw new NotImplementedException("This printer cannot scan!");
        }
        public void Fax()
        {
            throw new NotImplementedException("This printer cannot fax!");
        }
    }

    //public class Program
    //{
    //    static void Main()
    //    {
    //        IPrinter printer = new MultiFunctionPrinter();
    //        printer.Print();
    //        printer.Scan();
    //        printer.Fax();

    //        IPrinter basicPrinter = new BasicPrinter();
    //        basicPrinter.Print();
    //        basicPrinter.Scan();
    //        basicPrinter.Fax();
    //    }
    //}
    /* Good Example */

    public interface IPrinterMachine
    {
        void Print();
    }
    public interface IScannerMachine
    {
        void Scan();
    }
    public interface IFaxMachine
    {
        void Fax();
    }
    public class MultiFunctionMachine : IPrinterMachine, IScannerMachine, IFaxMachine
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
        public void Scan()
        {
            Console.WriteLine("Scanning...");
        }
        public void Fax()
        {
            Console.WriteLine("Faxing...");
        }
    }
    public class BasicPrinterMachine : IPrinterMachine
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    //public class ProgramTwo
    //{
    //    static void Main()
    //    {
    //        IPrinterMachine printer = new MultiFunctionMachine();
    //        printer.Print();

    //        IScannerMachine scanner = new MultiFunctionMachine();
    //        scanner.Scan();

    //        IFaxMachine fax = new MultiFunctionMachine();
    //        fax.Fax();

    //        IPrinterMachine basicPrinter = new BasicPrinterMachine();
    //        basicPrinter.Print();
    //    }
    //}
}
