namespace RhinoWpfIntro.ViewModels
{
    class RhinoWpfIntroViewModel:Rhino.UI.ViewModel
    {
        public RhinoWpfIntroViewModel(uint documentSerialNumber)
        {
            DocumentRuntimeSerialNumber = documentSerialNumber;
            Rhino.UI.Panels.Show += OnShowPanel;
        }

        private void OnShowPanel(object sender, Rhino.UI.ShowPanelEventArgs e)
        {
            var sn = e.DocumentSerialNumber;
        }
        private uint DocumentRuntimeSerialNumber { get; }

    }
}
