using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Badge
    {
        //List<Door> doors => (Door) id name
        //List<string> doors =>
        //in SeedMethod (Ui) -> var doors = new List<string>{"A1","B1"} (example of how this works)
        public Badge(){ }
        public Badge( List<string> doors)
        {
            
            Doors = doors;
        }
         public int ID { get; set; }
        public List<string> Doors { get; set; } = new List<string>();
        
    }
