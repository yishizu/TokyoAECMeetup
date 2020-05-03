using System;
using Rhino;
using Rhino.UI;
using Rhino.Commands;

namespace RhinoWPFIntroWorkshop
{
    public class ShowHelloPanel : Command
    {
        static ShowHelloPanel _instance;
        public ShowHelloPanel()
        {
            _instance = this;
        }

        ///<summary>The only instance of the ShowHelloPanel command.</summary>
        public static ShowHelloPanel Instance
        {
            get { return _instance; }
        }

        public override string EnglishName
        {
            get { return "ShowHelloPanel"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: complete command.
            Dialogs.ShowMessage("Hello World!" , "Hi, Everyone!");
            return Result.Success;
        }
    }
}