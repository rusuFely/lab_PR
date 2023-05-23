using lab3; //se specifică că se folosește spațiul de nume "lab3" 
using System.Net; //se importă clasa "System.Net" 

namespace lab3
{
    class Program //  se definește clasa "Program" în cadrul spațiului de nume "lab3"
    {
        private static string dnsServer; //se declară o variabilă statică numită "dnsServer"

        static void Main(string[] args) //se definește metoda statică "Main" care primește un array de șiruri de caractere numit "args"
        {
            while (true) // in ciclul while se așteaptă în mod continuu introducerea de la utilizator
            {
                Console.Write("Command: "); // se cere ca utilizatorul sa introduca o comanda
                string[] command = Console.ReadLine().Split(' '); //input. se citește linia introdusă de utilizator
                                                                  //folosind metoda "Console.ReadLine()" și se împarte într-un array de șiruri de caractere

                if (command[0].ToLower() == "resolve")
                {
                    if (IPAddress.TryParse(command[1], out IPAddress ip))
                    {
                        // Rezolvă domeniul pentru o adresă IP
                        string hostName = Dns.GetHostEntry(ip).HostName;
                        Console.WriteLine($"Host name for {ip}: {hostName}");
                    }
                    else
                    {
                        // Rezolvă adresele IP pentru un domain
                        IPAddress[] addresses = Dns.GetHostAddresses(command[1]);
                        Console.WriteLine($"IP addresses for {command[1]}:");

                        foreach (IPAddress address in addresses)
                        {
                            Console.WriteLine(address);
                        }
                    }
                }
                else if (command[0].ToLower() == "use" && command[1].ToLower() == "dns")
                {
                    // Schimbă DNS serverul implicit
                    dnsServer = command[2];
                    Console.WriteLine($"Using DNS server: {dnsServer}");
                }
                else
                {
                    Console.WriteLine("Invalid command"); // daca este introdusa o comanda diferita de cele de mai
                                                          // sus se afiseaza "Invalid command"
                }
            }
        }
    }
}
