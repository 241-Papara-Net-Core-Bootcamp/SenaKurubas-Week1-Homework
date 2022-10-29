using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;


namespace Owner.API.Data
{
    public class OwnerData
    {
        private List<Model.Owner> ownerList=new();

        public void AddToOwnerList(Model.Owner ownerToAdd)
        {
            ownerList.Add(ownerToAdd);
        }

        public void RemoveFromOwnerList(Model.Owner ownerToDelete)
        {
            ownerList.Remove(ownerToDelete);
        }

        public List<Model.Owner> GetOwnerList()
        {
            CreateOwnersData();
            return ownerList;
        }

        private void CreateOwnersData()
        {
            ownerList = new List<Model.Owner>()
            {
                new Model.Owner(1,"Sena","Kurubas",new DateTime(1997,05,19),"Description1","Type1"),
                new Model.Owner(2,"Furkan","Emir",new DateTime(1998,05,29),"Description2","Type2"),
                new Model.Owner(3,"Umut","Kurubas",new DateTime(1995,05,25),"Description3","Type3"),
                new Model.Owner(4,"Kagan","Emir",new DateTime(1990,03,28),"Description4","Type4"),
                new Model.Owner(5,"Veli","Emir",new DateTime(1995,08,25),"Description5","Type5"),
            };
        }

    }
    
}