using System;
using Xunit;

namespace Geometrie.DAL.Tests
{
    public class Cercle_DALTest
    {
        // Test du constructeur avec ID
        [Fact]
        public void Geometrie_DAL_Cercle_Constructor_With_Id()
        {
            // Arrange
            var centre = new Point_DAL(10, 20);
            double rayon = 15.5;

            // Act
            var cercle = new Cercle_DAL(1, centre, rayon);

            // Assert
            Assert.Equal(1, cercle.Id);
            Assert.Equal(centre, cercle.Centre);
            Assert.Equal(rayon, cercle.Rayon);
        }

        // Test du constructeur sans ID
        [Fact]
        public void Geometrie_DAL_Cercle_Constructor_Without_Id()
        {
            // Arrange
            var centre = new Point_DAL(5, 10);
            double rayon = 25.0;

            // Act
            var cercle = new Cercle_DAL(centre, rayon);

            // Assert
            Assert.Null(cercle.Id); // L'ID doit être nul
            Assert.Equal(centre, cercle.Centre);
            Assert.Equal(rayon, cercle.Rayon);
        }

        // Test du constructeur avec Theory pour plusieurs cas
        [Theory]
        [InlineData(10, 20, 15.5)]
        [InlineData(5, 10, 25.0)]
        public void Geometrie_DAL_Cercle_Constructor_Theory(int x, int y, double rayon)
        {
            // Arrange
            var centre = new Point_DAL(x, y);

            // Act
            var cercle = new Cercle_DAL(centre, rayon);

            // Assert
            Assert.Equal(centre, cercle.Centre);
            Assert.Equal(rayon, cercle.Rayon);
        }
    }
}