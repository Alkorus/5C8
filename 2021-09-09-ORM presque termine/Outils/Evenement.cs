using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse21.Outils
{
    // L'information transportée par l'évèenement
    public class ChangementProprioEventArgs
    {
        public int ProprioId { get; set; }

        public ChangementProprioEventArgs(int id)
        {
            ProprioId = id;
        }
    }

    


    // Le prototype que devront respecter les méthodes qui désirent réagir à l'évènement
    public delegate void ChangementProprioEventHandler(object sender, ChangementProprioEventArgs e);

    // Classe des évènements 
    public class EvenementBourse
    {
        static public event ChangementProprioEventHandler ChangementProprio;

        static public void OnChangementProprio(ChangementProprioEventArgs e)
        {
            ChangementProprio?.Invoke(null, e);
        }
    }
}
