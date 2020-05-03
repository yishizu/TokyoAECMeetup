namespace RhinoWpfIntro
{
    public class RhinoWpfIntroPlugIn : Rhino.PlugIns.PlugIn

    {
        public RhinoWpfIntroPlugIn()
        {
            Instance = this;
        }

        public static RhinoWpfIntroPlugIn Instance
        {
            get; private set;
        }
    }
}