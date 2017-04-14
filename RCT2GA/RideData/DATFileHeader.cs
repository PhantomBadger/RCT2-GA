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

        public DATFileFlags FileFlags { get; set; }
        public DATObjectType ObjectType { get; set; }

        public DATFileHeader(DATFileHeader copy)
        {
            if (copy.FileFlags != null)
            {
                FileFlags = new DATFileFlags(copy.FileFlags);
            }
            else
            {
                FileFlags = new DATFileFlags();
            }
            ObjectType = copy.ObjectType;
        }

        public DATFileHeader()
        {

        }

        public int CalculateChecksum(string filename)
        {

            return 0;
        }
    }
}
