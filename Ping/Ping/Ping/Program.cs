using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace PingTest
{
    public class PingProg
    {
        // Глобальная переменная. Принимает значение "0", если устройство доступно, в противном случае меняет значение на "1".
        int status_value = 0;
        
        public static void PingRequest(String ip)
        {
            PingProg ping_prog = new PingProg();
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            PingReply pingReply;

            options.DontFragment = true;
            byte[] buffer = new byte[32];
            int timeout = 500;
            try
            {
                pingReply = pingSender.Send(ip, timeout, buffer, options);

                if (pingReply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Статус: {0}", ping_prog.status_value);
                    Console.WriteLine("Состояние соединения: {0}", pingReply.Status);
                    Console.WriteLine("IP-адрес: {0}", pingReply.Address);
                    Console.WriteLine("Время ответа: {0}", pingReply.RoundtripTime);
                    Console.WriteLine("Размер буфера данных: {0}", pingReply.Buffer.Length);
                    Console.WriteLine("Число переадресаций: {0}", pingReply.Options.Ttl);
                    Console.WriteLine("Предотвращение фрагментации: {0}", pingReply.Options.DontFragment);
                    
                }
                else
                {
                    ping_prog.status_value = 1;
                    Console.WriteLine("Состояние соединения: {0}", pingReply.Status);
                    Console.WriteLine("Статус: {0}", ping_prog.status_value);
                    
                }
            }

            catch (System.Net.NetworkInformation.PingException)
            {
                Console.WriteLine("PingException");
            }
            catch (Exception eq)
            {
                Console.WriteLine("Another exception" + eq);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                Console.ReadLine();                
            }
            }
        // параметр args[0] является IPaddress или host namea.
        public static void Main(string[] args)
        {
            String ip="";
            while(!ip.Equals("exit!!"))
            {
                Console.WriteLine("Enter IP");
                ip = Console.ReadLine();
                PingRequest(ip);
                Console.Clear();
            }
        }
    }
}