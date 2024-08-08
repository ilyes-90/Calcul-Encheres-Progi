using Calcul.Encheres.DomainAffaire;

namespace Calcul.Encheres.Api.Entites
{
    public class VoitureDto
    {
        public EnumTypeVoiture TypeVoiture { get; set; }
        public decimal PrixDeBase { get; set; }
    }
}