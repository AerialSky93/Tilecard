using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tilcard.Models
{
    //Sample data for Demo Controller
    static class CardDemo
    {
        public static List<string> CardDemoData;

        static CardDemo()
        {
            CardDemoData = new List<string>
            {
                "https://images.pexels.com/photos/457882/pexels-photo-457882.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                "https://statesymbolsusa.org/sites/statesymbolsusa.org/files/styles/symbol_thumbnail__medium/public/primary-images/Applesfreshpicked.jpg?itok=YmYkBfY7",
                "https://www.mcpl.us/sites/default/files/styles/large/public/bookstack.jpg?itok=pHICdzg9",
                "https://media.wired.com/photos/5b86fce8900cb57bbfd1e7ee/master/w_582,c_limit/Jaguar_I-PACE_S_Indus-Silver_065.jpg",
                "https://atlantis.nyc3.digitaloceanspaces.com/styled/1bec9ec74aac91e70b3ef91fee1fc0f9",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3DXqVk9AhGSx2PIYoUepA1UfZFnGt_kY6iJTq3hb10ZLGhFwPQg",
                "https://youngisland.com/wp-content/uploads/2018/01/resort.png"
            };
        }
    }
}
