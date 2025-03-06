using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secret_chat_Client
{
    class prog
    {
        int LastX = 4, LastY = 4;
        int EnterX, EnterY;
         public void Mainprog()
        {



            //---------------------------------------------------------------------
            Client client;
            //---------------------------------------------------------------------


            //---------------------------------------------------------------------
            string _ip;
            int port;
            //---------------------------------------------------------------------





            //---------------------------------------------------------------------
            Console.Write("Enter Ip:");
            _ip = Console.ReadLine();
            Console.Write("Enter Port:");
            port = Convert.ToInt32(Console.ReadLine());
            //---------------------------------------------------------------------


            //---------------------------------------------------------------------
            client = new Client(_ip, port);
            client.ReciveEvent += recive;
            //---------------------------------------------------------------------



            Console.WriteLine("Connected...!");



            while (true)
            {
                //---------------------------------------------------------------------
                Console.SetCursorPosition(LastX, LastY);
                Console.Write("\nenter your message:");
                (LastX, LastY) = Console.GetCursorPosition();
                (EnterX, EnterY) = Console.GetCursorPosition();

                client.Send(Console.ReadLine());
                //---------------------------------------------------------------------

            }

        }

        public void recive(string message)
        {
            Console.SetCursorPosition(LastX, LastY);
            Console.WriteLine("\n" + message);
            (LastX, LastY) = Console.GetCursorPosition();
            Console.SetCursorPosition(EnterX, EnterY);


        }
    }
}

