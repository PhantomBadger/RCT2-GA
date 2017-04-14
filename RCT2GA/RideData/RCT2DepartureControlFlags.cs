using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2DepartureControlFlags
    {
        public bool UseMaximumTime { get; set; }
        public bool UseMinimumTime { get; set; }
        public bool SyncWithAdjacentStation { get; set; }
        public bool LeaveIfAnotherArrives { get; set; }
        public bool WaitForLoad { get; set; }
        public bool WaitForQuarterLoad { get; set; }
        public bool WaitForHalfLoad { get; set; }
        public bool WaitForThreeQuarterLoad { get; set; }
        public bool WaitForFullLoad { get; set; }
        public bool WaitForAnyLoad { get; set; }

        public RCT2DepartureControlFlags(RCT2DepartureControlFlags copy)
        {
            UseMaximumTime = copy.UseMaximumTime;
            UseMinimumTime = copy.UseMinimumTime;
            SyncWithAdjacentStation = copy.SyncWithAdjacentStation;
            LeaveIfAnotherArrives = copy.LeaveIfAnotherArrives;
            WaitForLoad = copy.WaitForLoad;
            WaitForQuarterLoad = copy.WaitForQuarterLoad;
            WaitForHalfLoad = copy.WaitForHalfLoad;
            WaitForThreeQuarterLoad = copy.WaitForThreeQuarterLoad;
            WaitForFullLoad = copy.WaitForFullLoad;
            WaitForAnyLoad = copy.WaitForAnyLoad;
        }

        public RCT2DepartureControlFlags()
        {

        }
    }
}
