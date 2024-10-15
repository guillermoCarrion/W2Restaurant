namespace Models;

class Pedido {
//private List<Producto> productos;
private List<(Producto, int)> productos; //tupla de Producto (item1) y cantidad (item2)
//Investiga las diferencias entre tupla y diccionario

public Pedido() {
    productos = new List<(Producto,int)>();
}

public void AnadirProductos(Producto producto, int cantidad = 1) {
    productos.Add((producto,cantidad));
    Console.WriteLine($"Producto añadido: {producto.Nombre}");
}

public void MostrarPedido() {
    Console.WriteLine("\n-------Pedido------");
    foreach (var producto in productos) {
        producto.Item1.MostrarDetalles();
        Console.WriteLine($"Cantidad: {producto.Item2}");
    }
}

public double CalcularTotal() {
    double total = 0;
    foreach (var producto in productos) {
        total += producto.Item1.Precio * producto.Item2;
    }
    return total;
}

}