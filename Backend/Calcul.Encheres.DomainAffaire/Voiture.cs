using System.Reflection;
using System.Text.Json.Serialization;

namespace Calcul.Encheres.DomainAffaire
{
    public abstract class Voiture
    {
        public EnumTypeVoiture TypeVoiture { get; set; }
        public decimal PrixDeBase { get; set; }
        public abstract decimal CalculPrixTotal();

        public decimal CalculFraisSupplementairesAssociation()
        {
            if (PrixDeBase >= 1 && PrixDeBase <= 500)
            {
                return 5m;
            }
            else if (PrixDeBase > 500 && PrixDeBase <= 1000)
            {
                return 10m;
            }
            else if (PrixDeBase > 1000 && PrixDeBase <= 3000)
            {
                return 15m;
            }
            else if (PrixDeBase > 3000)
            {
                return 20m;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Montant invalide.");
            }
        }

        public decimal CalculFraisEntreposage()
        {
            return 100m;
        }
    }
}
