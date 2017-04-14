using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFBaseClass
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WCFBaseClass : IWCFBaseClass
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public Success<Pet> GetSuccessPet(int id)
        {
            return new Success<Pet> { Value = new Pet { ID = 10, Name = "Freddy Ferret" } };
        }
      
        public Fallible<Pet> GetFalliblePet(int id)
        {
            //Fallible<Pet> result;
            //result= new Success<Pet> { Value = new Pet { ID = 10, Name = "Freddy Ferret" } };
            return new Success<Pet> { Value = new Pet { ID = 10, Name = "Freddy Ferret" } };
            //return result;
        }

        public Fallible<Pet> GetFalliblePetTest(int id)
        {
            //Fallible<Pet> result;
            //result= new Success<Pet> { Value = new Pet { ID = 10, Name = "Freddy Ferret" } };
            return new Success<Pet> { Value = new Pet { ID = 10, Name = "Freddy Ferret" } };
            //return result;
        }

    }
}
