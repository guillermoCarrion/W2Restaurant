using System.Runtime.CompilerServices;

namespace Models;

class Pedido {
//private List<Producto> productos;
private List<(Producto, int)> productos; //tupla de Producto (item1) y cantidad (item2)
//Investiga las diferencias entre tupla y diccionario

public double Descuento {get; set;} = 0;
public double Impuesto {get; set;} = 0.21;

public DateTime FechaPedido {get; set;}




public Pedido() {
    productos = new List<(Producto,int)>();
    FechaPedido = DateTime.Now;
}

public void AnadirProductos(Producto producto, int cantidad = 1) {
    productos.Add((producto,cantidad));
    Console.WriteLine($"Producto añadido: {producto.Nombre}");
}

public void EliminarProductos(Producto producto, int cantidad = 1) {
    productos.Remove((producto,cantidad));
    Console.WriteLine($"Producto añadido: {producto.Nombre}");
}


public void MostrarPedido() {
    Console.WriteLine("\n-------Pedido------");
    
    var fechaPedidoString = "22/10/24 23:12";
    var fechaPedidoStringConverted = Convert.ToDateTime(fechaPedidoString);
    
    
    var fechaPedido = FechaPedido;
    var fechaPedidoSinSegundos = FechaPedido.ToString("dd/MM/yy HH:mm");
    Console.WriteLine ($"\n----({fechaPedido})----");
    foreach (var producto in productos) {
        producto.Item1.MostrarDetalles();
        Console.WriteLine($"Cantidad: {producto.Item2}");
    }
}

public double CalcularTotal() {
    double total = 0;
    foreach (var (producto, cantidad) in productos) {
        total += producto.Precio * cantidad;
    }
    var totalConImpuesto = total * (1+Impuesto);
    var totalConDescuento = totalConImpuesto * (1-Descuento);
    return totalConDescuento;
}


public void GuardarPedido(string rutaFichero) {
    using (StreamWriter sw = new StreamWriter(rutaFichero)) {

        foreach (var item in productos ) {
            Producto producto = item.Item1;
            int cantidad = item.Item2;


            if ( producto is PlatoPrincipal plato) {
                var message = $"PlatoPrincipal | {plato.Nombre} | {plato.Precio} | {plato.Ingredientes}";
                sw.WriteLine(message);
            }
            
            if ( producto is Bebida bebida) {
                
            }
            if ( producto is Postre postre) {
                
            }
        }
    }
}


public void CargarPedido(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split('|');
                    string tipoProducto = datos[0];
                    string nombre = datos[1];
                    double precio = double.Parse(datos[2]);
                    int cantidad = 0; //int.Parse(datos[4]);
 
                    if (tipoProducto == "PlatoPrincipal")
                    {
                        string ingredientes = datos[3];
                        PlatoPrincipal plato = new PlatoPrincipal(nombre, precio, ingredientes);
                        AnadirProductos(plato, cantidad);
                    }
                    else if (tipoProducto == "Bebida")
                    {
                        bool esAlcoholica = bool.Parse(datos[3]);
                        Bebida bebida = new Bebida(nombre, precio, esAlcoholica);
                        AnadirProductos(bebida, cantidad);
                    }
                    else if (tipoProducto == "Postre")
                    {
                        int calorias = int.Parse(datos[3]);
                        Postre postre = new Postre(nombre, precio, calorias);
                        AnadirProductos(postre, cantidad);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("No se encontró el archivo.");
        }
    }
}





/*
public double CalcularImpuestos(){
    var iva = 0.21;
    return CalcularTotal() * (1+iva);
}

public double AplicarDescuento(double descuento){
    return CalcularTotal() * (1-descuento);
}
*/

