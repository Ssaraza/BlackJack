using System;
System.Random random = new System.Random();

int totalJugador = 0;
int totalDealer = 0;
int num = 0;
int Fichas = 0;
string message = "";
string controlOtraCarta = "";
string switchControl = "menu";
bool controlWhile = true;
int fichasJuego = 0;
int Apuesta = 0;

Console.WriteLine("Bienvenido a tu C A S I N O !");
Console.WriteLine("¿Cuántas Fichas deseas? \n" +
                   "Ingresa un número entero \n" +
                   "Recuerda que necesitas 1 por ronda");
Fichas = int.Parse(Console.ReadLine());


for (int i = Fichas; i >= 1; i--)
{
    totalJugador = 0;
    totalDealer = 0;
    controlWhile = true;

    while (controlWhile) 
    {
        switch (switchControl)
        {
            case "menu":

                if (i == 0)
                {
                    controlWhile = false;
                    break;
                }
                Console.WriteLine($"Tienes {i} fichas");

                Console.WriteLine("¿Cuántas fichas deseas apostar? ");
                Apuesta = int.Parse(Console.ReadLine());

                if (!(Apuesta > 0 && Apuesta <= i))
                {
                    Console.WriteLine("Apueste un valor válido");
                    break; 
                }
                i -= Apuesta;
                fichasJuego = Apuesta * 2;

                Console.WriteLine("Escriba ‘21’ para jugar al BlackJack");
                switchControl = Console.ReadLine();
                break;

            case "21":
                do
                {
                    num = random.Next(1, 11);
                    totalJugador = totalJugador + num;
                    Console.WriteLine("Toma tu carta, jugador,");
                    Console.WriteLine($"Te salió el número: {num} ");
                    Console.WriteLine("¿Deseas otra carta ?");
                    controlOtraCarta = Console.ReadLine();

                } while (controlOtraCarta == "Si" ||
                         controlOtraCarta == "si" ||
                         controlOtraCarta == "SI");

                totalDealer = random.Next(10, 25);
                Console.WriteLine($"El dealer tiene {totalDealer}");

                if (totalJugador > totalDealer && totalJugador < 22)
                {
                    message = "Venciste al dealer, felicidades";
                    switchControl = "menu";
                    i += fichasJuego;
                    controlWhile = false;
                }
                else if (totalJugador >= 22)
                {
                    message = "Perdiste vs el dealer, te pasaste de 21";
                    switchControl = "menu";
                    controlWhile = false;
                }
                else if (totalJugador <= totalDealer)
                {
                    message = "Perdiste vs el dealer, lo siento";
                    switchControl = "menu";
                    controlWhile = false;
                }
                else
                {
                    message = "condición no válida";
                }
                Console.WriteLine(message);
                break;
            default:
                Console.WriteLine("Valor ingresa no válido en el  C A S I N O");
                break;
        }
        
    }
}
Console.WriteLine("Te quedaste sin fichas, el C A S I N O Ganó.");
 