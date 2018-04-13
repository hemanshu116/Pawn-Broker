using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawn_Broker.Views;

namespace Pawn_Broker.ViewModels
{
    public class SetListBoxHomepage
    {
        private ViewBills _viewBills;
        private DeleteBills _deleteBills;


        public ListboxViewModelHomepage[] ListItems { get; }

        public SetListBoxHomepage()
        {
            _viewBills = new ViewBills();
            _deleteBills = new DeleteBills();
            ListItems = new[]
            {
                new ListboxViewModelHomepage("VIEW BILLS", _viewBills),
                new ListboxViewModelHomepage("DELETE BILLS", _deleteBills),
            };
        }
    }
}
