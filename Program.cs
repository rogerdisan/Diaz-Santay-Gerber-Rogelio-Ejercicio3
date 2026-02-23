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
    case 1: // Estudiante
        if (pago == 1)
        {
            descuento = monto * 0.10;
        }
        else if (pago == 2)
        {
            descuento = monto * 0.07;
        }
        else if (pago == 3)
        {
            descuento = monto * 0.05;
        }
        break;

    case 2: // Docente
        if (pago == 1)
        {
            descuento = monto * 0.15;
        }
        else if (pago == 2)
        {
            descuento = monto * 0.10;
        }
        else if (pago == 3)
        {
            descuento = monto * 0.08;
        }
        break;

    case 3: // Administrativo
        if (pago == 1)
        {
            descuento = monto * 0.20;
        }
        else if (pago == 2)
        {
            descuento = monto * 0.12;
        }
        else if (pago == 3)
        {
            descuento = monto * 0.10;
        }
        break;

    case 4: // Externo
        if (pago == 1)
        {
            descuento = monto * 0.05;
        }
        else if (pago == 2)
        {
            descuento = monto * 0.02;
        }
        break;

    default:
        Console.WriteLine("Cliente no valido");
        return;
}

if (tieneCupon == 'S' && codigoCupon.Length >= 2)
{
    char primera = codigoCupon[0];
    char ultima = codigoCupon[codigoCupon.Length - 1];

    if (primera == 'U' && char.IsDigit(ultima))
    {
        int ultimoNumero = int.Parse(ultima.ToString());
        if (ultimoNumero % 2 == 0)
        {
            descuento += monto * 0.05;
        }
        else
        {
            Console.WriteLine("Cupon invalido");
        }
    }
    else
    {
        Console.WriteLine("Cupon invalido");
    }
}

if (fraude == 2 || fraude == 3)
{
    Console.WriteLine("ALERTA: Posible fraude detectado");
    descuento = 0;
    recargo = monto * 0.10;
}

total = monto - descuento + recargo;

Console.WriteLine("\n=== FACTURA ===");
Console.WriteLine("Monto base: " + monto);
Console.WriteLine("Descuento: " + descuento);
Console.WriteLine("Recargo: " + recargo);
Console.WriteLine("TOTAL: " + total);
