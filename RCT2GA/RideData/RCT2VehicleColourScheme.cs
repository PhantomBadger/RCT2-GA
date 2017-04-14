using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2VehicleColourScheme
    {
        public enum RCT2VehicleColourMode { AllSameColour,
                                            TrainsDiffColour,
                                            CarDiffColour };
        public enum RCT2Colour {    Black,
                                    Grey,
                                    White,
                                    DarkPurple,
                                    LightPurple,
                                    BrightPurple,
                                    DarkBlue,
                                    LightBlue,
                                    IcyBlue,
                                    Teal,
                                    Aquamarine,
                                    SaturatedGreen,
                                    DarkGreen,
                                    MossGreen,
                                    BrightGreen,
                                    OliveGreen,
                                    DarkOliveGreen,
                                    BrightYellow,
                                    Yellow,
                                    DarkYellow,
                                    LightOrange,
                                    DarkOrange,
                                    LightBrown,
                                    SaturatedBrown,
                                    DarkBrown,
                                    SalmonPink,
                                    BordeauxRed,
                                    SaturatedRed,
                                    BrightRed,
                                    DarkPink,
                                    BrightPink,
                                    LightPink };

        public RCT2VehicleColourMode ColourMode { get; set; }
        public RCT2Colour[] BodyColours { get; set; }
        public RCT2Colour[] TrimColours { get; set; }
        public RCT2Colour[] AdditionalColours { get; set; }

        public RCT2VehicleColourScheme(RCT2VehicleColourScheme copy)
        {
            ColourMode = copy.ColourMode;
            BodyColours = (RCT2Colour[])copy.BodyColours.Clone();
            TrimColours = (RCT2Colour[])copy.TrimColours.Clone();
            AdditionalColours = (RCT2Colour[])copy.AdditionalColours.Clone();
        }

        public RCT2VehicleColourScheme()
        {

        }
    }
}
