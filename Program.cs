Console.WriteLine("=== Sistema de Facturacion ===");
Console.WriteLine("Tipo de cliente:");
Console.WriteLine("1. Estudiante");
Console.WriteLine("2. Docente");
Console.WriteLine("3. Administrativo");
Console.WriteLine("4. Externo");
Console.Write("Seleccione: ");

int cliente = int.Parse(Console.ReadLine());

Console.Write("Monto base: ");
double monto = double.Parse(Console.ReadLine());
if (monto <= 0)
{
    Console.WriteLine("Monto no valido");
    return;
}

Console.Write("Metodo de pago (1.Efectivo 2.Tarjeta 3.Transferencia): ");
int pago = int.Parse(Console.ReadLine());

Console.Write("Tiene cupon (S/N): ");
char tieneCupon = char.Parse(Console.ReadLine().ToUpper());

string codigoCupon = "";
if (tieneCupon == 'S')
{
    Console.Write("Codigo de cupon: ");
    codigoCupon = Console.ReadLine().ToUpper();
}

Console.WriteLine("Reporte antifraude:");
Console.WriteLine("1. Ninguno");
Console.WriteLine("2. Cupon invalido repetido");
Console.WriteLine("3. Pagos rechazados multiples");
Console.Write("Seleccione: ");
int fraude = int.Parse(Console.ReadLine());

double descuento = 0;
double recargo = 0;
double total = monto;

switch (cliente)
{
