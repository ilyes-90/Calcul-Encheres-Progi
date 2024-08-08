using Calcul.Encheres.DomainAffaire;

namespace Calcul.Encheres.Services
{
    public class CalculEncheresServices : ICalculEncheresServices
    {
        public virtual decimal CalculPrixTotal(Voiture voiture)
        {
            return voiture.CalculPrixTotal();
        }

        public virtual Voiture CreationVoiture(EnumTypeVoiture typeVoiture, decimal PrixDeBase)
        {
            switch (typeVoiture)
            {
                case EnumTypeVoiture.Ordinaire:
                    return new VoitureOrdinaire()
                    {
                        PrixDeBase = PrixDeBase,
                        TypeVoiture = typeVoiture
                    };
                case EnumTypeVoiture.Luxe:
                    return new VoitureLuxe
                    {
                        PrixDeBase = PrixDeBase,
                        TypeVoiture = typeVoiture
                    };
                default:
                    throw new ArgumentException("Type de voiture n'existe pas.");
            }
        }
    }
}