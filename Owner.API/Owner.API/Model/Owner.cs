using System;
using System.Xml.Linq;


namespace Owner.API.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public Owner(int id, string name, string surname, DateTime date, string description, string type)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Date = date;
            this.Description = description;
            this.Type = type;
        }

        public void UpdateInformation(int id, string name, string surname, DateTime date, string description, string type)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Date = date;
            this.Description = description;
            this.Type = type;
        }

        public void UpdateInformation(Model.Owner newOwner)
        {
            this.Id = newOwner.Id;
            this.Name = newOwner.Name;
            this.Surname = newOwner.Surname;
            this.Date = newOwner.Date;
            this.Description = newOwner.Description;
            this.Type = newOwner.Type;
        }
    }
}