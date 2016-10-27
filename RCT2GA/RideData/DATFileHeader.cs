using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class DATFileHeader
    {
        public enum DATObjectType{  RideShop,
                                    SmallScenery,
                                    LargeScenery,
                                    Walls,
                                    PathBanners,
                                    Path,
                                    PathAdditions,
                                    SceneryGroup,
                                    ParkEntrance,
                                    Water,
                                    ScenarioText };

        public string FileName { get; set; }
        public DATFileFlags FileFlags { get; set; }
        public DATObjectType ObjectType { get; set; }

        public int CalculateChecksum()
        {
            //TODO
            return 0;
        }
    }
}
