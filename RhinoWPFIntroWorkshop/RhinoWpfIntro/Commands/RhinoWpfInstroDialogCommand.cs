using Rhino;
using Rhino.Commands;
using RhinoWindows;

namespace RhinoWpfIntro.Commands
{
    public class RhinoWpfInstroDialogCommand : Command
    {

        public override string EnglishName => "RhinoWpfInstroDialog";
        
        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var dialog = new Views.RhinoWpfIntroDialog();
            dialog.ShowSemiModal(RhinoApp.MainWindowHandle());

            return Result.Success;
        }
    }
}