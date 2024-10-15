using Models;

public class PlatoPrincipal : Producto {

    public string Ingredientes {get;set;}

public PlatoPrincipal(string nombre, double precio, string ingredientes): base(nombre, precio) {
   Ingredientes = ingredientes;
}

    public override void MostrarDetalles() {
        Console.WriteLine($"Plato principal: {Nombre}, Precio {Precio:C}, Ingredientes {Ingredientes} ");
    }
}