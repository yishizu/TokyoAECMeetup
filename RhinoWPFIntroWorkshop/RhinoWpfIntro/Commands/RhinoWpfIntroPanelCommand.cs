using System;
using System.Runtime.InteropServices;
using Rhino;
using Rhino.UI;
using RhinoWpfIntro.Views;
using Rhino.Commands;


namespace RhinoWpfIntro
{
    [Guid("1FB4EA3D-1C26-40D4-A70A-D19D7E43AB46")]

    public class RhinoWpfIntroPlanelHost : RhinoWindows.Controls.WpfElementHost
    {
        public RhinoWpfIntroPlanelHost(uint docsn) : base(new RhinoWpfIntroPanel(docsn), null)
        {
        }
    }
    public class RhinoWpfIntroPanelCommand : Command
    {
        
        public RhinoWpfIntroPanelCommand()
        {
            Instance = this;
            Panels.RegisterPanel(RhinoWpfIntroPlugIn.Instance, typeof(RhinoWpfIntroPlanelHost), "MyUIPanel", System.Drawing.SystemIcons.WinLogo);
        }

        ///<summary>The only instance of this command.</summary>
        public static RhinoWpfIntroPanelCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "MyUIPanel"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            // ---
            var panel_id = typeof(RhinoWpfIntroPlanelHost).GUID;
            var panel_visible = Panels.IsPanelVisible(panel_id);
            if (!panel_visible)
                Panels.OpenPanel(panel_id);
            
            return Result.Success;
        }
    }
}
