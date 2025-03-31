namespace SOLIDPrinciple._3_LiskovSubstitutionPrinciple
{
    /* L – Liskov Substitution Principle (LSP) */
    /* The Liskov Substitution Principle states that objects of a superclass
      should be replaceable with objects of its subclasses without affecting the
      functionality of the program. */

    /* Bad Example */
    public class VehicleLSP
    {
        public virtual void Refuel()
        {
            Console.WriteLine("Refueling the vehicle...");
        }
    }
    public class ElectricVehicle : VehicleLSP
    {
        public override void Refuel()
        {
            throw new NotImplementedException("Electric cars cannot be refueled!");
        }
    }
    //class VehicleProgram
    //{
    //    static void Main()
    //    {
    //        VehicleLSP vehicle = new ElectricVehicle();  // Violates LSP
    //        vehicle.Refuel(); // Will throw an exception
    //    }
    //}

    /* Good Example */

    public interface IVehicle
    {
        void Refuel();
    }
    public interface IElectricVehicle 
    {
        void ChargeBattery();
    }
    public abstract class Vehicle
    {
        public string CarName { get; set; } = string.Empty;
    }
    public class PetrolCar : Vehicle,IVehicle
    {
        public virtual void Refuel()
        {
            Console.WriteLine("Refueling the vehicle...");
        }
    }

    public class ElectricCar : Vehicle, IElectricVehicle
    {
        public void ChargeBattery()
        {
            Console.WriteLine("Recharging the electric car...");
        }
    }

    //class VehicleProgramTwo
    //{
    //    static void Main()
    //    {
    //        IVehicle petrolCar = new PetrolCar();
    //        petrolCar.Refuel(); 

    //        IElectricVehicle tesla = new ElectricCar();
    //        tesla.ChargeBattery(); 
    //    }
    //}
}
