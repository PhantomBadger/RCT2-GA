using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class DATFileFlags
    {
        public bool IsStandardObject { get; set; } = false;
        public bool IsCustomObject { get; set; } = false;

        public DATFileFlags(DATFileFlags copy)
        {
            IsStandardObject = copy.IsStandardObject;
            IsCustomObject = copy.IsCustomObject;
        }

        public DATFileFlags()
        {

        }
    }
}
