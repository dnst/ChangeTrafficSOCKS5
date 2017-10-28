using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socks5_new
{
    class ChangePackage
    {
        public static void ChangePack(ref DataChange packet)
        {
            if (packet.Status == 0)
            {
                int len = 1300;
                if (DataChange.Reserve + packet.Received < len)
                {
                    Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                    DataChange.Reserve += packet.Received;
                }
                else
                {
                    Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                    DataChange.Reserve += packet.Received;

                    //Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                    Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, len);

                    DataChange.Reserve -= len;
                    packet.Received = len;

                    //Array.Copy(packet.Buffer, 205, DataChange.ReserveBuffer, 0, DataChange.Reserve);
                    Array.Copy(DataChange.ReserveBuffer, len, DataChange.ReserveBuffer, 0, DataChange.Reserve);

                    packet.Status = 1;
                    packet.Send = 1;
                }
            }
            else
            {
                if (packet.Status == 1)
                {
                    int len = 700;
                    if (DataChange.Reserve + packet.Received < len)
                    {
                        Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                        DataChange.Reserve += packet.Received;
                    }
                    else
                    {
                        Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                        DataChange.Reserve += packet.Received;

                        //Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                        Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, len);

                        DataChange.Reserve -= len;
                        packet.Received = len;

                        //Array.Copy(packet.Buffer, 155, DataChange.ReserveBuffer, 0, DataChange.Reserve);
                        Array.Copy(DataChange.ReserveBuffer, len, DataChange.ReserveBuffer, 0, DataChange.Reserve);

                        packet.Status = 2;
                        packet.Send = 1;
                    }
                }
                else
                {
                    if (packet.Status == 2)
                    {
                        int len = 300;
                        if (DataChange.Reserve + packet.Received < len)
                        {
                            Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                            DataChange.Reserve += packet.Received;
                        }
                        else
                        {
                            Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                            DataChange.Reserve += packet.Received;
                            
                            //Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                            Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, len);

                            DataChange.Reserve -= len;
                            packet.Received = len;

                            //Array.Copy(packet.Buffer, 105, DataChange.ReserveBuffer, 0, DataChange.Reserve);
                            Array.Copy(DataChange.ReserveBuffer, len, DataChange.ReserveBuffer, 0, DataChange.Reserve);

                            packet.Status = 0;
                            packet.Send = 1;
                        }
                    }
                }
            }


        }



        public static void ChangePack1(ref DataChange packet)
        {
            if (packet.Status == 0)
            {
                Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                DataChange.Reserve += packet.Received;
                packet.Status = 1;
            }
            else
            {
                Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                DataChange.Reserve += packet.Received;
                Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                packet.Received = DataChange.Reserve;
                DataChange.Reserve = 0;
                packet.Status = 0;
                packet.Send = 1;
            }

        }




        public static void ChangePack2(ref DataChange packet)
        {
            int len = 3000;
            if (DataChange.Reserve + packet.Received < len)
            {
                Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                DataChange.Reserve += packet.Received;
            }
            else
            {
                Array.Copy(packet.Buffer, 5, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received);
                DataChange.Reserve += packet.Received;

                //Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);

                packet.Received = DataChange.Reserve;
                DataChange.Reserve = 0;

                //Array.Copy(packet.Buffer, 105, DataChange.ReserveBuffer, 0, DataChange.Reserve);
                //Array.Copy(DataChange.ReserveBuffer, len, DataChange.ReserveBuffer, 0, DataChange.Reserve);

                packet.Send = 1;
            }

        }


        public static void ChangePack3(ref DataChange packet)
        {
            if (packet.Status == 0)
            {
                int len = 1100;
                if (DataChange.Reserve + packet.Received - 2 < len)
                {
                    Array.Copy(packet.Buffer, 7, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received - 2);
                    DataChange.Reserve += packet.Received - 2;
                }
                else
                {
                    Array.Copy(packet.Buffer, 7, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received - 2);
                    DataChange.Reserve += packet.Received - 2;

                    //Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                    Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 7, len);

                    DataChange.Reserve -= len;
                    packet.Received = len;

                    //Array.Copy(packet.Buffer, 205, DataChange.ReserveBuffer, 0, DataChange.Reserve);
                    Array.Copy(DataChange.ReserveBuffer, len, DataChange.ReserveBuffer, 0, DataChange.Reserve);

                    packet.Status = 1;
                    packet.Send = 1;
                }
            }
            else
            {
                if (packet.Status == 1)
                {
                    int len = 1000;
                    if (DataChange.Reserve + packet.Received - 2 < len)
                    {
                        Array.Copy(packet.Buffer, 7, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received - 2);
                        DataChange.Reserve += packet.Received - 2;
                    }
                    else
                    {
                        Array.Copy(packet.Buffer, 7, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received - 2);
                        DataChange.Reserve += packet.Received - 2;

                        //Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                        Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 7, len);

                        DataChange.Reserve -= len;
                        packet.Received = len;

                        //Array.Copy(packet.Buffer, 155, DataChange.ReserveBuffer, 0, DataChange.Reserve);
                        Array.Copy(DataChange.ReserveBuffer, len, DataChange.ReserveBuffer, 0, DataChange.Reserve);

                        packet.Status = 2;
                        packet.Send = 1;
                    }
                }
                else
                {
                    if (packet.Status == 2)
                    {
                        int len = 900;
                        if (DataChange.Reserve + packet.Received - 2 < len)
                        {
                            Array.Copy(packet.Buffer, 7, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received - 2);
                            DataChange.Reserve += packet.Received - 2;
                        }
                        else
                        {
                            Array.Copy(packet.Buffer, 7, DataChange.ReserveBuffer, DataChange.Reserve, packet.Received - 2);
                            DataChange.Reserve += packet.Received - 2;

                            //Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 5, DataChange.Reserve);
                            Array.Copy(DataChange.ReserveBuffer, 0, packet.Buffer, 7, len);

                            DataChange.Reserve -= len;
                            packet.Received = len;

                            //Array.Copy(packet.Buffer, 105, DataChange.ReserveBuffer, 0, DataChange.Reserve);
                            Array.Copy(DataChange.ReserveBuffer, len, DataChange.ReserveBuffer, 0, DataChange.Reserve);

                            packet.Status = 0;
                            packet.Send = 1;
                        }
                    }
                }
            }


        }












    
    }
}
