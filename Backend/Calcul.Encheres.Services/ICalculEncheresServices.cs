using Calcul.Encheres.DomainAffaire;

namespace Calcul.Encheres.Services
{
    public interface ICalculEncheresServices
    {
        decimal CalculPrixTotal(Voiture voiture);
        Voiture CreationVoiture(EnumTypeVoiture typeVoiture, decimal PrixDeBase);
    }
}