using System;

namespace Sabotage {
    public class ClientSend {
        private static void SendTCPData(Packet packet) {
            packet.WriteLength();
            Client.instance.tcp.SendData(packet);
        }
        // Define a function for each type of instruction we expect to send
        public static void welcomeReceived() {
            using (Packet packet = new Packet((int)ClientPackets.welcomeReceived)) {
                packet.Write(Client.instance.myID);
                packet.Write("Hello from Matt!");

                SendTCPData(packet);
            }
        }

        public static void Fire(int x, int y) {
            using (Packet packet = new Packet((int)ClientPackets.fire)) {
                packet.Write(Client.instance.myID);
                packet.Write(x);
                packet.Write(y);

                SendTCPData(packet);
            }
        }

        public static void ConfirmHit(int x, int y, bool hitShip) {
            using (Packet packet = new Packet((int)ClientPackets.confirmHit)) {
                packet.Write(Client.instance.myID);
                packet.Write(x);
                packet.Write(y);
                packet.Write(hitShip);

                SendTCPData(packet);
            }
        }

        public static void ConfirmServiceSunk(string serviceName) {
            using (Packet packet = new Packet((int)ClientPackets.serviceSunk)) {
                packet.Write(Client.instance.myID);
                packet.Write(serviceName);

                SendTCPData(packet);
            }
        }

        public static void ConfirmAllServicesSunk() {
            using (Packet packet = new Packet((int)ClientPackets.allServicesSunk)) {
                SendTCPData(packet);
            }
        }
    }
}