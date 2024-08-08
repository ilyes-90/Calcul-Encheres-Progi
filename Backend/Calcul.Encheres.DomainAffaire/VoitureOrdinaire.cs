namespace Calcul.Encheres.DomainAffaire
{
    public class VoitureOrdinaire : Voiture
    {
        public override decimal CalculPrixTotal()
        {
            return PrixDeBase + CalculFraisDeBase() + CalculFraisSpeciaux() + CalculFraisSupplementairesAssociation() + CalculFraisEntreposage();
        }

        private decimal CalculFraisDeBase()
        {
            if (PrixDeBase * 0.1m > 50m)
            {
                return 50m;
            }
            else if (PrixDeBase * 0.1m < 10m)
            {
                return 10m;
            }
            return PrixDeBase * 0.1m; 
        }

        private decimal CalculFraisSpeciaux()
        {
            return PrixDeBase * 0.02m;
        }
    }
}
