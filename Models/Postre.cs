using Models;

public class Postre : Producto {

    public int Calorias {get;set;}
    public bool ConAzucar {get;set;}

public Postre(string nombre, double precio, int calorias): base(nombre, precio) {
   Calorias = calorias;
}

    public override void MostrarDetalles() {
        Console.WriteLine($"Postre: {Nombre}, Precio {Precio:C}, Calorías {Calorias} ");
    }
}