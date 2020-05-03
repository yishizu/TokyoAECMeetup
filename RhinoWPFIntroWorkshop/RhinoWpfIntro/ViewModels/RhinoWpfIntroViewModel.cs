using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Message
        {
            get => m_message ?? string.Empty;
            set => SetProperty(value, ref m_message);
        }
        private string m_message;

        

    }
}
