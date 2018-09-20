using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace AppBox.Model
{
    public class DropListClass
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public DropListClass()
        {

        }
        public DropListClass(object Entity, string IDname, string Namename)
        {
            string id= (string)Entity.GetType().GetProperty(IDname).GetValue(Entity,null);
            string Name = (string)Entity.GetType().GetProperty(Namename).GetValue(Entity, null);
            this.ID = id;
            this.Name = Name;
        }
        public DropListClass(string IDName, string _Name)
        {
            this.ID = IDName;
            this.Name = _Name;


        }
    }
}