using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS_NET_MAUI.Models
{
    public partial class SOSModel : ObservableObject
    {
        public SOSModel(int index)
        {
            this.Index = index;
        }
        public int Index { get; set; }



        [ObservableProperty]
        private string _selectedText;

        // Player 0 equal X
        // Player 1 = O
        // null means not player selected

        public int? Player { get; set; }
    }
}
