using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openstreet_laba
{
    public class CityClass
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public List<CityBuilding> Buildings { get; set; }

        public CityClass(string _nm)
        {
            Name = _nm;
            Population = 0;
            Buildings = new List<CityBuilding>();
        }
    }

    public class CityBuilding
    {
        public int ID
        {
            get
            {
                try
                {
                    return int.Parse(IdStr);
                }
                catch
                {
                    return 0;
                }
            }
        }
        public string Type { get; set; }
        public int Levels { get; set; }
        public string Name { get; set; }
        public double Lat
        {
            get
            {
                try
                {
                    return double.Parse(LatStr.Replace('.', ','));
                }
                catch
                {
                    return 0;
                }
            }
        }
        public double Lon
        {
            get
            {
                try
                {
                    return double.Parse(LonStr.Replace('.', ','));
                }
                catch
                {
                    return 0;
                }
            }
        }
        public string Description { get; set; }
        public string IdStr { get; set; }
        public string LatStr { get; set; }
        public string LonStr { get; set; }
        public string NdId { get; set; }


        public CityBuilding()
        {
            //ID = 0;
            Type = "unknow";
            Levels = 0;
            Name = "none";
            Description = "";
            IdStr = "";
            LatStr = "";
            LonStr = "";
            NdId = "";
        }

        public override string ToString()
        {
            return Name + ". " + Type + ". " + Description;
        }
    }
}
