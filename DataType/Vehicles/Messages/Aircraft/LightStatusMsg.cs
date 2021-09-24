using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Messages.Aircraft
{
    public class LightStatusMsg : Message
    {
        public int ANTI_COLLISION = 0;
        public int TAXI = 0;
        public int LANDING = 0;
        public int STROBE = 0;
        public int NAVIGATION_RED = 0;
        public int NAVIGATION_GREEN = 0;
        public int NAVIGATION_WHITE = 0;
        public int SURFACE_INSPECTION;
        public int LOGO = 0;

        public LightStatusMsg(int antiCollision, int taxi, int landing, int strobe, int navigationRed, int navigationGreen,  int navigationWhite, int surfaceInpsection, int logo)
        {
            ANTI_COLLISION = antiCollision;
            TAXI = taxi;
            LANDING = landing;
            STROBE = strobe;
            NAVIGATION_RED = navigationRed;
            NAVIGATION_GREEN = navigationGreen;
            NAVIGATION_WHITE = navigationWhite;
            SURFACE_INSPECTION = surfaceInpsection;
            LOGO = logo;
        }
    }
}
