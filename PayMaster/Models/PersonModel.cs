
namespace PayMaster
{
    internal class PersonModel
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonNick { get; set; }
        public bool PersonArchived { get; set; }

        public PersonModel(int personId, string personName, string personSurname, string personNick, bool personArchived)
        {
            PersonId = personId;
            PersonName = personName;
            PersonSurname = personSurname;
            PersonNick = personNick;
            PersonArchived = personArchived;
        }

        public PersonModel(int personId, string personNick)
        {
            PersonId = personId;
            PersonNick = personNick;
        }

        public PersonModel(string personName, string personSurname, string personNick, bool personArchived)
        {
            PersonName = personName;
            PersonSurname = personSurname;
            PersonNick = personNick;
            PersonArchived = personArchived;
        }


    }
}
