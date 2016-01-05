using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace TestPhotonServer
{
    public class PPeer:PeerBase
    {
        public PPeer(InitRequest initRequest) : base(initRequest)
        {
        }

        public PPeer(IRpcProtocol protocol, IPhotonPeer unmanagedPeer) : base(protocol, unmanagedPeer)
        {
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var response = new OperationResponse(operationRequest.OperationCode);
            this.SendOperationResponse(response, sendParameters);
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            //throw new NotImplementedException();
        }
    }
}
