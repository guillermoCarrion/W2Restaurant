namespace Models;

public abstract class Producto {
    public string Nombre {get;set;}
    public double Precio {get;set;}

    public Producto(string nombre, double precio) {
        Nombre = nombre;
        Precio = precio;
    }

    public abstract void MostrarDetalles();

}
