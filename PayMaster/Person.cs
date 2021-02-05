using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster
{
    class Person
    {
       
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonNick { get; set; }
        public bool PersonArchived { get; set; }

        public Person(int personId, string personName, string personSurname, string personNick, bool personArchived)
        {
            this.PersonId = personId;
            this.PersonName = personName;
            this.PersonSurname = personSurname;
            this.PersonNick = personNick;
            this.PersonArchived = personArchived;
        }

        public Person(string personName, string personSurname, string personNick, bool personArchived)
        {
            this.PersonName = personName;
            this.PersonSurname = personSurname;
            this.PersonNick = personNick;
            this.PersonArchived = personArchived;
        }


    }
}
