using Geometrie.BLL.Depots;
using Geometrie.BLL;
using Geometrie.DAL;
using Microsoft.EntityFrameworkCore;

public class Cercle_DepotTests
{
    private Point_Depot pointDepot;
    private GeometrieContext context; // Déclaration du context à l'échelle de la classe

    public Cercle_DepotTests()
    {
        // Initialisation du context en dehors du "using"
        context = new GeometrieContext();
        pointDepot = new Point_Depot(context);
    }

    // Test pour l'ajout d'un cercle
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_Add()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);
        var centre = new Point(1, 2);  // Centre du cercle
        var rayon = 5.0;  // Rayon du cercle
        var cercle = new Cercle(centre, rayon);  // Création du cercle avec centre et rayon

        // Act
        var result = depot.Add(cercle);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Id);
        Assert.Equal(1, result.Centre.X);
        Assert.Equal(2, result.Centre.Y);
        Assert.Equal(5.0, result.Rayon);
    }



    // Test pour l'ajout d'un cercle avec une valeur null
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_Add_ArgumentNullException()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => depot.Add(null));
    }

    // Test pour la suppression d'un cercle
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_Delete()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);
        var centre = new Point(1, 2);  // Centre du cercle
        var rayon = 5.0;  // Rayon du cercle
        var cercle = new Cercle(centre, rayon);

        // Ajouter le cercle au dépôt
        depot.Add(cercle);

        // Assurez-vous que le cercle a bien été ajouté
        Assert.Contains(depot.GetAll(), c => c.Centre.X == centre.X && c.Centre.Y == centre.Y && c.Rayon == cercle.Rayon);

        // Act
        // Supprimer le cercle
        var result = depot.Delete(cercle);

        // Assert
        // Vérifiez que le résultat est le même dépôt
        Assert.Same(depot, result);

        // Vérifiez que le cercle n'existe plus dans la base de données
        Assert.DoesNotContain(depot.GetAll(), c => c.Centre.X == centre.X && c.Centre.Y == centre.Y && c.Rayon == cercle.Rayon);
    }


    // Test pour la suppression d'un cercle avec une valeur null
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_Delete_ArgumentNullException()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => depot.Delete(null));
    }

    // Test pour récupérer tous les cercles
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_GetAll()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);
        var centre = new Point(1, 2);  // Centre du cercle
        var rayon = 5.0;  // Rayon du cercle
        var cercle = new Cercle(centre, rayon);
        depot.Add(cercle);

        // Act
        var result = depot.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Contains(result, c => c.Centre.X == 1 && c.Centre.Y == 2 && c.Rayon == 5);
    }

    // Test pour récupérer un cercle par son Id
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_GetById()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);
        var centre = new Point(1, 2);  // Centre du cercle
        var rayon = 5.0;  // Rayon du cercle
        var cercle = new Cercle(centre, rayon);
        var addedCercle = depot.Add(cercle);

        // Act
        var result = depot.GetById(addedCercle.Id.Value);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Centre.X);
        Assert.Equal(2, result.Centre.Y);
        Assert.Equal(5, result.Rayon);
    }

    // Test pour la mise à jour d'un cercle
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_Update()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);
        var centre = new Point(1, 2);
        var cercle = new Cercle(centre, 5); // Création d'un cercle avec centre et rayon
        var addedCercle = depot.Add(cercle);

        var updatedCentre = new Point(3, 4);
        var updatedCercle = new Cercle(updatedCentre, 6); // Mise à jour avec un nouveau centre et rayon

        // Act
        var result = depot.Update(updatedCercle);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Centre.X);
        Assert.Equal(4, result.Centre.Y);
        Assert.Equal(6, result.Rayon);
    }

    // Test pour la mise à jour d'un cercle avec une valeur null
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_Update_ArgumentNullException()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => depot.Update(null));
    }

    // Test pour la mise à jour d'un cercle sans Id
    [Fact]
    public void Geometrie_DAL_Cercle_Depot_Update_ArgumentNullException_Id()
    {
        // Arrange
        var depot = new Cercle_Depot(context, pointDepot);
        var centre = new Point(1, 2);  // Centre du cercle
        var rayon = 5.0;  // Rayon du cercle
        var cercle = new Cercle(centre, rayon);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => depot.Update(cercle));
    }
}
