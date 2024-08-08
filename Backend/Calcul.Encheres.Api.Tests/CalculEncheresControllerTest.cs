using Calcul.Encheres.Api.Controllers;
using Calcul.Encheres.Api.Entites;
using Calcul.Encheres.DomainAffaire;
using Calcul.Encheres.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Calcul.Encheres.Api.Tests
{
    public class CalculEncheresControllerTest
    {
        private readonly Mock<ICalculEncheresServices> _mockCalculEncheresServices;
        private readonly CalculEncheresController _controllerEncheresController;

        public CalculEncheresControllerTest()
        {
            _mockCalculEncheresServices = new Mock<ICalculEncheresServices>();
            _controllerEncheresController = new CalculEncheresController(_mockCalculEncheresServices.Object);
        }

        [Fact]
        public void CalculPrixTotal_RetournerBadRequest_QuandVoitureEstNull()
        {
            // Act
            var resultat = _controllerEncheresController.CalculPrixTotal(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultat.Result);
        }

        [Fact]
        public void CalculPrixTotal_ReturnsOk_AvecBonPrixTotal()
        {
            // Arrange
            var voitureDto = new VoitureDto
            {
                PrixDeBase = 11000m,
                TypeVoiture = EnumTypeVoiture.Ordinaire
            };

            var voiture = new VoitureOrdinaire
            {
                PrixDeBase = voitureDto.PrixDeBase,
                TypeVoiture = voitureDto.TypeVoiture
            };

            _mockCalculEncheresServices.Setup(s => s.CreationVoiture(voitureDto.TypeVoiture, voitureDto.PrixDeBase))
                                       .Returns(voiture);
            _mockCalculEncheresServices.Setup(s => s.CalculPrixTotal(voiture))
                                       .Returns(1287m);

            // Act
            var resultat = _controllerEncheresController.CalculPrixTotal(voitureDto);

            // Assert
            Assert.IsType<OkObjectResult>(resultat.Result);
            var okResult = resultat.Result as OkObjectResult;
            Assert.Equal(1287m, okResult.Value);
        }

        [Fact]
        public void CalculPrixTotal_LancerException_QuandCreationVoitureEchoue()
        {
            // Arrange
            var voitureDto = new VoitureDto
            {
                PrixDeBase = 10000m,
                TypeVoiture = EnumTypeVoiture.Ordinaire
            };

            _mockCalculEncheresServices.Setup(s => s.CreationVoiture(voitureDto.TypeVoiture, voitureDto.PrixDeBase))
                        .Throws(new ArgumentException("Type de voiture n'existe pas."));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _controllerEncheresController.CalculPrixTotal(voitureDto));
        }
    }
}