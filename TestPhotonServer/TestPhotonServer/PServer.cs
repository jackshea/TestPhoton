using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;

namespace TestPhotonServer
{
    public class PServer : ApplicationBase
    {
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new PPeer(initRequest);
        }

        protected override void Setup()
        {
            //throw new NotImplementedException();
        }

        protected override void TearDown()
        {
            //throw new NotImplementedException();
        }
    }
}
