using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


#if UNITY_EDITOR

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


#endif



/*
* Unity is not able to natively support UWP functions and recent C# APIs
* "#if WINDOWS_UWP" indicates unity to neglect the upcoming lines while in editor mode,
* however, it will implement the funcitonality once the solution is being compiled.
*/



#if WINDOWS_UWP
using Windows.Networking.Sockets;
using Windows.Networking.Connectivity;
using Windows.Networking;
using Windows.Storage.Streams;


#endif
namespace DTStacks.Communication.UDP
{
    public class UDPTransceiver : MonoBehaviour
    {

        /*
         * By default, this script contains a debug option which broadcasts error messages through the network
         * allowing insight into possible issues. 
         * 
         * Furthermore it contains a communication option XY which is capable of sending and receiving messages. 
         * If more than a single channel is needed, copy all regions marked with "XY" and replace all "XY"-letters with 
         * a description of choice. Make sure to do the same within the Start() and Update() voids.
         * 
         * Make sure to change the sendPort and receivePort as well, every port can only be accessed once at a time, meaning each port
         * must be unique. It turned out to be handy to use ports in pairs. E.G 20020 for sending and 20021 for receiving. Also for sending 
         * and receiving the port values shall be unique!
         * 
         * 
         * 
         * 
         */



        #region  VariablePool

        #region common Variables
        public static string broadcastIP = "255.255.255.255";
        public static int errorPort = 7018;
        public static string pingString = "Application Starting Up";
        private static bool remoteDeviceHandshake = false;

        #endregion




        #region XY variables
        public UnityEvent XY_msgReceived;
        private bool new_XY_msgReceived = false;

        public static string XY_sendIP = "255.255.255.255";
        public static int XY_receivePort = 20020;
        public static int XY_sendPort = 20021;
        public static string XY_recMsg = "Hello World?";
        public static string XY_sendMsg = "";

        #region channel_1 variables
        public UnityEvent channel_1_msgReceived;
        private bool new_channel_1_msgReceived = false;

        public static string channel_1_sendIP = "255.255.255.255";
        public static int channel_1_receivePort = 20030;
        public static int channel_1_sendPort = 20031;
        public static string channel_1_recMsg = "channel_1Port Open";
        public static string channel_1_sendMsg = "";
        #endregion

        #region channel_2 variables
        public UnityEvent channel_2_msgReceived;
        private bool new_channel_2_msgReceived = false;

        public static string channel_2_sendIP = "255.255.255.255";
        public static int channel_2_receivePort = 20032;
        public static int channel_2_sendPort = 20033;
        public static string channel_2_recMsg = "channel_2Port Open";
        public static string channel_2_sendMsg = "";
        #endregion




#if WINDOWS_UWP
    DatagramSocket XY_recSock;
    DatagramSocket channel_1_recSock;
    DatagramSocket channel_2_recSock;
#endif
        #endregion
#if UNITY_EDITOR

        Thread channel_1_Thread;
        Thread channel_2_Thread;

#endif



        #endregion


        /*
         * Within the Start() function, the XY receiving socket is instantiated, this is only possible ouside of the Unity Editor.
         * Hence while Unity is playing the scene, it will not be active and therefore not display anything. Yet once compiled to a 
         * Visual Studio solution, these lines will be active and functional.
         * 
         * Next up the Unity Event is created that shall be triggered once a new message is received, using this method, other functions 
         * can be called with the event. Technically it is also possible to save the message in a public static string, public static integer (etc.) 
         * however, using the event system, unnecessary processing is prevented. 
         * 
         */
        void Start()
        {


#if WINDOWS_UWP
        XY_recListener();
        channel_1_recListener();
        channel_2_recListener();
#endif
            if (XY_msgReceived == null) XY_msgReceived = new UnityEvent();
            if (channel_1_msgReceived == null) channel_1_msgReceived = new UnityEvent();
            if (channel_2_msgReceived == null) channel_2_msgReceived = new UnityEvent();

#if WINDOWS_UWP
        SendUDP_ErrorMessage(pingString);
#endif

#if UNITY_EDITOR
            channel_1_Thread = new Thread(Channel_1_Thread);
            channel_1_Thread.IsBackground = true;
            channel_1_Thread.Start();
            channel_2_Thread = new Thread(Channel_2_Thread);
            channel_2_Thread.IsBackground = true;
            channel_2_Thread.Start();
#endif


        }
        #region Unity Functions
#if UNITY_EDITOR

        public static void UnityUDPSend(string ip, int port, string msg)
        {
            //Debug.Log(ip);
            UdpClient udpClient = new UdpClient();
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

            Byte[] sendBytes = Encoding.ASCII.GetBytes(msg);
            try
            {
                udpClient.Send(sendBytes, sendBytes.Length, ipEndPoint);
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
            udpClient.Dispose();
        }



        public static void Channel_1_Thread()
        {
            UdpClient channel_1_Client = new UdpClient(channel_1_receivePort);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    Byte[] recBytes = channel_1_Client.Receive(ref ipEndPoint);
                    Debug.Log(ipEndPoint.ToString());
                    if (Encoding.ASCII.GetString(recBytes) == "1")
                    {
                        remoteDeviceHandshake = true;
                        channel_1_sendIP = ipEndPoint.Address.ToString();
                        channel_2_sendIP = ipEndPoint.Address.ToString();
                        Debug.Log(channel_1_sendIP);
                    }
                }
                catch
                {

                }
            }
        }

        public static void Channel_2_Thread()
        {
            UdpClient channel_2RecClient = new UdpClient(channel_2_receivePort);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    Byte[] recBytes = channel_2RecClient.Receive(ref ipEndPoint);

                    if (Encoding.ASCII.GetString(recBytes) == "1")
                    {
                        remoteDeviceHandshake = true;
                        channel_1_sendIP = ipEndPoint.Address.ToString();
                        channel_2_sendIP = ipEndPoint.Address.ToString();
                    }
                }
                catch
                {

                }
            }
        }


#endif
        #endregion

        /*
         * The only purpose of the Update() function is to check if the boolean regarding a new message on channel XY is received. If it is the case, 
         * the correpsonding event is triggered and other functions within the application can be activated. Once the event is invoked, the boolen is
         * switched back to false, preventing multiple triggers if nothing was received.
         * 
         */


        void Update()
        {
            if (new_XY_msgReceived == true)
            {
                try
                {
                    XY_msgReceived.Invoke();
                    new_XY_msgReceived = false;

                }
                catch (Exception e)
                {
                    Debug.Log(e);
#if WINDOWS_UWP
                SendUDP_ErrorMessage(e.ToString());
#endif
                }
            }
            if (new_channel_1_msgReceived == true)
            {
                try
                {
                    channel_1_msgReceived.Invoke();
                    new_channel_1_msgReceived = false;

                }
                catch (Exception e)
                {
                    Debug.Log(e);
#if WINDOWS_UWP
                SendUDP_ErrorMessage(e.ToString());
#endif
                }
            }

            if (new_channel_2_msgReceived == true)
            {
                try
                {
                    channel_2_msgReceived.Invoke();
                    new_channel_2_msgReceived = false;

                }
                catch (Exception e)
                {
                    Debug.Log(e);
#if WINDOWS_UWP
                SendUDP_ErrorMessage(e.ToString());
#endif
                }
            }

            if (remoteDeviceHandshake)
            {
                Sendchannel_1Message("2");
                Sendchannel_2Message("2");

                remoteDeviceHandshake = false;

#if UNITY_EDITOR
                channel_2_Thread.Abort();
                channel_1_Thread.Abort();
#endif
            }
        }



        #region XY Voids and functions

        /*
         * private async void XY_recListener: 
         * Instantiate a new Datagram socket on the XY_receivePort as defined in the Variable Pool, this socket will be the entry 
         * point for external communication with other devices and/or programs running on the same device.
         * Furthermore, the internal listening event is initiated with " XY_recSock.MessageReceived += XY_recSock_MessageReceived; "
         * 
         * 
         * 
         * async void XY_recSock_MessageReceived:
         * Gets triggered if a new mesage is incoming on the defined XY_recPort, it receives the data, registers the remoteHost (transmitter),
         * saves the device address and name temporarily and saves the transmitted data in a string format. Once the message is successfully stored as 
         * a string, the boolean for a new received message ( new_XY_msgReceived ) is set to true. hence within the next update function the 
         * UnityEvent ( XY_msgReceived) is triggered and the string processed somewhere, depending on the logic connected to the UnityEvent.
         * 
         * 
         */


#if WINDOWS_UWP
    private async void XY_recListener()
    {
        XY_recSock = new DatagramSocket();
        XY_recSock.MessageReceived += XY_recSock_MessageReceived;
        await XY_recSock.BindServiceNameAsync(XY_receivePort.ToString());
    }   

    void XY_recSock_MessageReceived(DatagramSocket socket, DatagramSocketMessageReceivedEventArgs args)
    {
        try
        {
            DataReader reader = args.GetDataReader();
            uint len = reader.UnconsumedBufferLength;
            string msg = reader.ReadString(len);
            string remoteHost = args.RemoteAddress.DisplayName;
            reader.Dispose();
            XY_recMsg = msg;

            // The received information is stored in msg and then saved to XY_recMsg, therefore the information is copied and the boolean is switched to true
            // Thus, with the next time the update-funtion is called, the information will be processed according to what is stated in the update function.

            try
            {
                if( XY_recMsg == "1")
                {
                   SendUDPMessage(XY_sendIP, XY_sendPort, "2"); //initially ping to eventually change from broadcasted to direct messages, acts as verification
                }
                else {
            
                }
                new_XY_msgReceived = true;
            }
            catch (Exception e)
            {
                SendUDP_ErrorMessage(e.ToString());
            }
        }
        catch(Exception e)
        {
            SendUDP_ErrorMessage(e.ToString());
        }
    }
#endif
        #endregion


        #region channel_1Functions
#if WINDOWS_UWP

        private async void channel_1_recListener()
    {
        channel_1_recSock = new DatagramSocket();
        channel_1_recSock.MessageReceived += channel_1_recSock_MessageReceived;
        await channel_1_recSock.BindServiceNameAsync(channel_1_receivePort.ToString());
    }   

    void channel_1_recSock_MessageReceived(DatagramSocket socket, DatagramSocketMessageReceivedEventArgs args)
    {
        try
        {
            DataReader reader = args.GetDataReader();
            uint len = reader.UnconsumedBufferLength;
            string msg = reader.ReadString(len);
            string remoteHost = args.RemoteAddress.DisplayName;
            reader.Dispose();
            channel_1_recMsg = msg;

            // The received information is stored in msg and then saved to channel_1_recMsg, therefore the information is copied and the boolean is switched to true
            // Thus, with the next time the update-funtion is called, the information will be processed according to what is stated in the update function.

            try
            {
                //initially ping to eventually change from broadcasted to direct messages, acts as verification
                if( channel_1_recMsg == "1")
                {
                    channel_2_sendIP = remoteHost;
                    channel_1_sendIP = remoteHost;
                    remoteDeviceHandshake = true;
                    
                }
                else {
            
                }
                new_channel_1_msgReceived = true;
            }
            catch (Exception e)
            {
                SendUDP_ErrorMessage(e.ToString());
            }
        }
        catch(Exception e)
        {
            SendUDP_ErrorMessage(e.ToString());
        }
    }
#endif
        #endregion

        #region channel_2Functions
#if WINDOWS_UWP

        private async void channel_2_recListener()
    {
        channel_2_recSock = new DatagramSocket();
        channel_2_recSock.MessageReceived += channel_2_recSock_MessageReceived;
        await channel_2_recSock.BindServiceNameAsync(channel_2_receivePort.ToString());
    }   

    void channel_2_recSock_MessageReceived(DatagramSocket socket, DatagramSocketMessageReceivedEventArgs args)
    {
        try
        {
            DataReader reader = args.GetDataReader();
            uint len = reader.UnconsumedBufferLength;
            string msg = reader.ReadString(len);
            string remoteHost = args.RemoteAddress.DisplayName;
            channel_2_sendIP = remoteHost;
            channel_1_sendIP = remoteHost;
            
            reader.Dispose();
            channel_2_recMsg = msg;

            // The received information is stored in msg and then saved to channel_2_recMsg, therefore the information is copied and the boolean is switched to true
            // Thus, with the next time the update-funtion is called, the information will be processed according to what is stated in the update function.

            try
            {
                //initially ping to eventually change from broadcasted to direct messages, acts as verification
                if( channel_2_recMsg == "1")
                {                    
                    remoteDeviceHandshake = true;
                    channel_2_sendIP = remoteHost;
                    channel_1_sendIP = remoteHost;
                }
                else {
            
                }
                new_channel_2_msgReceived = true;
            }
            catch (Exception e)
            {
                SendUDP_ErrorMessage(e.ToString());
            }
        }
        catch(Exception e)
        {
            SendUDP_ErrorMessage(e.ToString());
        }
    }
#endif
        #endregion

        #region General voids and functions

        /*
         * public void SendErrorMessage: 
         * Enables other scripts somewhere within the application to easily send an error message through the network to 
         * the defined errorPort. Implemented for easier debugging once the application is running on the HoloLens itself.
         * 
         * 
         * public async void SendUDPMessage:
         * Intermediate void used to trigger the async subfunction "await _SendUDPMessage" which actually handles the sending 
         * process within the CommunicationManager.
         * 
         * 
         * public async void SendUDP_ErrorMessage:
         * Intermediate void used to send error messages easily. Practically does the same as SendUDPMessage, yet the port and 
         * IP are fixed specified. Only the outgoing message to be broadcasted needs to be defined (string data).
         * 
         * 
         * private async System.Threading.Tasks.Task _SendUDPMessage:
         * The actual function that sends out messages. It creates a Datagram Socket on a random available port of the device used
         * and sends out the defined message to the desired IP and Port. The Datagram socket is disposed by the system directly once the 
         * message is send sucessfully and the end of the void is reached. Hence, the port is available again for all applications running on the device.
         * (Note: It is possible to use a specific Port for sending, yet not necessary. It could be of interest for special situations 
         * where the listening device shall react to a specific transmitting port. As a way of verification for example.)
         * 
         * 
         * 
         */

        public void SendErrorMessage(string data)
        {
#if WINDOWS_UWP
        SendUDP_ErrorMessage(data);
#endif
#if UNITY_EDITOR
            UnityUDPSend(broadcastIP, errorPort, data);
#endif
        }


        public void Sendchannel_1Message(string data)
        {
#if WINDOWS_UWP
         SendUDPMessage(channel_1_sendIP, channel_1_sendPort, data);
#endif

#if UNITY_EDITOR
            UnityUDPSend(channel_1_sendIP, channel_1_sendPort, data);
#endif
        }

        public void Sendchannel_2Message(string data)
        {
#if WINDOWS_UWP
         SendUDPMessage(channel_2_sendIP, channel_2_sendPort, data);
#endif
#if UNITY_EDITOR
            UnityUDPSend(channel_2_sendIP, channel_2_sendPort, data);
#endif
        }


#if WINDOWS_UWP
    public async void SendUDPMessage(string IP, int Port, string data)
    {
        await _SendUDPMessage(IP, Port.ToString(), Encoding.UTF8.GetBytes(data));
    }


    public async void SendUDP_ErrorMessage(string data)
    {
        await _SendUDPMessage(broadcastIP, errorPort.ToString(),Encoding.UTF8.GetBytes(data));
    }


    private async System.Threading.Tasks.Task _SendUDPMessage(string externalIP, string externalPort, byte[] data)
    {
        DatagramSocket socket = new DatagramSocket();
        using (var stream = await socket.GetOutputStreamAsync(new Windows.Networking.HostName(externalIP), externalPort.ToString()))
        {
            using (var writer = new Windows.Storage.Streams.DataWriter(stream))
                {
                    writer.WriteBytes(data);
                    await writer.StoreAsync();
                }
        }
    }

#endif
        #endregion

    }
}