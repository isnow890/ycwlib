using System.Net.NetworkInformation;

namespace ChanWooLib.Functions
{
    public static class PingTest
    {
        public static bool Ping(string _address)
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(_address);
            if (reply.Status== IPStatus.Success)
            {
                return true;
            }
            return false;
        }
    }
}