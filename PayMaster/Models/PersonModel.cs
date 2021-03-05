
namespace PayMaster
{
    class PersonModel
    {
       
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonNick { get; set; }
        public bool PersonArchived { get; set; }

        public PersonModel(int personId, string personName, string personSurname, string personNick, bool personArchived)
        {
            this.PersonId = personId;
            this.PersonName = personName;
            this.PersonSurname = personSurname;
            this.PersonNick = personNick;
            this.PersonArchived = personArchived;
        }

        public PersonModel(int personId, string personNick)
        {
            this.PersonId = personId;
            this.PersonNick = personNick;
        }

        public PersonModel(string personName, string personSurname, string personNick, bool personArchived)
        {
            this.PersonName = personName;
            this.PersonSurname = personSurname;
            this.PersonNick = personNick;
            this.PersonArchived = personArchived;
        }


    }
}
