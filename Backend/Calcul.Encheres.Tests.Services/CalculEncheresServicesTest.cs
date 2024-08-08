using Calcul.Encheres.DomainAffaire;
using Calcul.Encheres.Services;

namespace Calcul.Encheres.Services.Tests
{
    public class CalculEncheresServicesTest
    {
        [Fact]
        public void CalculPrixTotal_RetournerBonPrixTotal_PourVoitureOrdinaire()
        {
            // Arrange
            var service = new CalculEncheresServices();
            var voiture = new VoitureOrdinaire
            {
                PrixDeBase = 398m,
                TypeVoiture = EnumTypeVoiture.Ordinaire
            };

            // Act
            var totalPrice = service.CalculPrixTotal(voiture);

            // Assert
            Assert.Equal(550.76m, totalPrice); 
        }

        [Fact]
        public void CalculPrixTotal_RetournerBonPrixTotal_PourVoitureDeLuxe()
        {
            // Arrange
            var service = new CalculEncheresServices();
            var voiture = new VoitureLuxe
            {
                PrixDeBase = 1800m,
                TypeVoiture = EnumTypeVoiture.Luxe
            };

            // Act
            var totalPrice = service.CalculPrixTotal(voiture);

            // Assert
            Assert.Equal(2167m, totalPrice);
        }

        [Fact]
        public void CreationVoiture_DoitRetournerVoitureOrdinaire()
        {
            // Arrange
            var service = new CalculEncheresServices();
            var prixDeBase = 10000m;
            var typeVoiture = EnumTypeVoiture.Ordinaire;

            // Act
            var voiture = service.CreationVoiture(typeVoiture, prixDeBase);

            // Assert
            Assert.IsType<VoitureOrdinaire>(voiture);
            Assert.Equal(prixDeBase, voiture.PrixDeBase);
            Assert.Equal(typeVoiture, voiture.TypeVoiture);
        }

        [Fact]
        public void CreationVoiture_DoitRetournerVoitureDeLuxe()
        {
            // Arrange
            var service = new CalculEncheresServices();
            var prixDeBase = 10000m;
            var typeVoiture = EnumTypeVoiture.Luxe;

            // Act
            var voiture = service.CreationVoiture(typeVoiture, prixDeBase);

            // Assert
            Assert.IsType<VoitureLuxe>(voiture);
            Assert.Equal(prixDeBase, voiture.PrixDeBase);
            Assert.Equal(typeVoiture, voiture.TypeVoiture);
        }

        [Fact]
        public void CreationVoiture_DoitRetournerErreur_TypeInexistant()
        {
            // Arrange
            var service = new CalculEncheresServices();
            var prixDeBase = 10000m;
            var typeVoiture = (EnumTypeVoiture)555;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.CreationVoiture(typeVoiture, 10000m));
        }
    }
}