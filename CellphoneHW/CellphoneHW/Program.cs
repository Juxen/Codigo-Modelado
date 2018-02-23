using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellphoneHW
{ 
    /// Modelado
    
    //Celulares
    class Samsung
    {
        public String Puerto;

        public Samsung()
        {
            Puerto = "MicroUSB";
        }

       
    }
    public class iPhone
    {
        public String Puerto;

        public iPhone()
        {
            Puerto = "C";
        }

        
    
    }
    //CABLES MicroUSB y Tipo-C
    class USBC
    {
        public String conexion1 = "C";
        public String conexion2 = "USB";

        public USBC()
        {

        }
        public void ConnectPhone(iPhone iphone)
        {
            if (conexion1 == iphone.Puerto)
                Console.WriteLine("Se conecto el cable tipo-C al iPhone");
        }
    }
    class MicroUSB
    {
        public String conexion1 = "MicroUSB";
        public String conexion2 = "USB";

        public MicroUSB()
        {

        }
        public void ConnectPhone(Samsung samsung)
        {
            if (conexion1 == samsung.Puerto)
                Console.WriteLine("Se conecto el cable microUSB al Samsung");
        }
    }
    //Interfaz que sirve como adaptador para enchufe EU
    public interface IAdapterEU
    {
       String UseAdapterEU();
       String DetachAdapterEU();

    }
    //Cabecilla o Conector que va al enchufe
    class Conector : IAdapterEU
    {
        public String cableport = "USB";
        public String plug = "USA";

        public String UseAdapterEU() //Metodo para utilizar el adaptador EU
        {
            plug = "EU";
            Console.WriteLine("Se utilizo un adaptador EU en el conector");
            return plug;
        }
        public String DetachAdapterEU()
        {  
            if(plug == "EU")
            Console.WriteLine("Se quito el adaptador EU del conector");
            plug = "USA";
            return plug;
        }
        public Conector()
        {
          
        }
        
        public void ConnectCable(String conexion2)
        {
            if (cableport == conexion2)
                Console.WriteLine("Se conecto el extremo USB del cable a la cabecilla(conector)");
        }
     
    }
    //Enchufe de EU y USA
    class USAplug
    {
        public String plug = "USA";
        
        public USAplug()
        {
           
        }

        public void PlugConnector(Conector conector)
        {
            if (plug == conector.plug)
                Console.WriteLine("Se conecto la cabecilla al enchufe de USA");
        }
    }
    class EUplug
    {
        public String plug = "EU";

        public EUplug()
        {

        }

        public void PlugConnector(Conector conector)
        {
            if (plug == conector.plug)
                Console.WriteLine("Se conecto la cabecilla al enchufe de EU");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Instanciacion de las clases
            iPhone iPhone5 = new iPhone(); 
            Samsung S8 = new Samsung();   
            USBC cableC = new USBC(); 
            MicroUSB cablemicro = new MicroUSB(); 
            Conector cabecilla = new Conector(); 
            USAplug enchufeUSA = new USAplug();          
            EUplug enchufeEU = new EUplug(); 

            cableC.ConnectPhone(iPhone5);
            cabecilla.ConnectCable(cableC.conexion2);
            cabecilla.UseAdapterEU(); //adaptador para enchufe EU
            enchufeEU.PlugConnector(cabecilla);
            
            Console.WriteLine();

            cablemicro.ConnectPhone(S8);
            cabecilla.ConnectCable(cablemicro.conexion2);
            cabecilla.DetachAdapterEU(); //quitar el adaptador si se utilizo anteriormente
            enchufeUSA.PlugConnector(cabecilla);


            Console.ReadLine();

        }
    }
}
