using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse21.Outils
{
    // L'information transporter par l'évènement
    public class ChangementProprioEventArgs
    {
        public int ProprioId { get; set; }
        public int versionImage { get; set; }

        public ChangementProprioEventArgs(int id, int vi)
        {
            ProprioId = id;
            versionImage = vi;
        }
    }

    public class ModificationImageProprioEventArgs
    {
        public int Id { get; set; }
        public int Version { get; set; }

        public ModificationImageProprioEventArgs(int i, int vi)
        {
            Id = i;
            Version = vi;
        }
    }

    // Le prototype que devront respecter les méthodes qui désirent réagir à l'évènement
    public delegate void ChangementProprioEventHandler(object sender, ChangementProprioEventArgs e);
    public delegate void ModificationImageProprioEventHandler(object sender, ModificationImageProprioEventArgs e);

    // Classe des évènements 
    public class EvenementBourse
    {
        static public event ChangementProprioEventHandler ChangementProprio;
        static public event ModificationImageProprioEventHandler ModificationImageProprio;

        static public void OnChangementProprio(ChangementProprioEventArgs e)
        {
            ChangementProprio?.Invoke(null, e);
        }

        static public void OnModificationImageProprio(ModificationImageProprioEventArgs e)
        {
            ModificationImageProprio?.Invoke(null, e);
        }


    }
}
