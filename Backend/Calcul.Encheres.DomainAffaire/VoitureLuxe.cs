namespace Calcul.Encheres.DomainAffaire
{
    public class VoitureLuxe : Voiture
    {
        public override decimal CalculPrixTotal()
        {
            return PrixDeBase + CalculFraisDeBase() + CalculFraisSpeciaux() + CalculFraisSupplementairesAssociation() + CalculFraisEntreposage();
        }

        private decimal CalculFraisDeBase()
        {
            if (PrixDeBase * 0.1m > 200m)
            {
                return 200m;
            }
            else if (PrixDeBase * 0.1m < 25m)
            {
                return 25m;
            }
            return PrixDeBase * 0.1m;
        }

        private decimal CalculFraisSpeciaux()
        {
            return PrixDeBase * 0.04m;
        }
    }
}
