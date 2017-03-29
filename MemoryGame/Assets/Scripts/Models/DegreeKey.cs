using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public class DegreeKey
    {
        public int ID { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public DegreeKey(int ID, int num1, int num2)
        {
            this.ID = ID;
            Num1 = num1;
            Num2 = num2;
        }

        public override bool Equals(object obj)
        {
            var item = obj as DegreeKey;

            if (item == null)
            {
                return false;
            }

            return (Num1.Equals(item.Num1) && Num2.Equals(item.Num2));
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

    }
}
