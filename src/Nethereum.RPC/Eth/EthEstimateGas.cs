using System.Threading.Tasks;
using edjCase.JsonRpc.Client;
using edjCase.JsonRpc.Core;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.Transactions;
using Nethereum.RPC.Generic;
using RPCRequestResponseHandlers;

namespace Nethereum.RPC.Eth
{

    ///<Summary>
       /// eth_estimateGas
/// 
/// Makes a call or transaction, which won't be added to the blockchain and returns the used gas, which can be used for estimating the used gas.
/// 
/// Parameters
/// 
/// See eth_call parameters, expect that all properties are optional.
/// 
/// Returns
/// 
/// QUANTITY - the amount of gas used.
/// 
/// Example
/// 
///  Request
/// curl -X POST --data '{"jsonrpc":"2.0","method":"eth_estimateGas","params":[{see above}],"id":1}'
/// 
///  Result
/// {
///   "id":1,
///   "jsonrpc": "2.0",
///   "result": "0x5208" // 21000
/// }    
    ///</Summary>
    public class EthEstimateGas : RpcRequestResponseHandler<HexBigInteger>
        {
            public EthEstimateGas(RpcClient client) : base(client, ApiMethods.eth_estimateGas.ToString()) { }

            public async Task<HexBigInteger> SendRequestAsync( EthCallTransactionInput ethCallInput, BlockParameter block, string id = Constants.DEFAULT_REQUEST_ID)
            {
                return await base.SendRequestAsync(id, ethCallInput, block);
            }

        public async Task<HexBigInteger> SendRequestAsync(EthCallTransactionInput ethCallInput, string id = Constants.DEFAULT_REQUEST_ID)
        {
            return await SendRequestAsync(ethCallInput, BlockParameter.CreateLatest(), id);
        }

        public RpcRequest BuildRequest(EthCallTransactionInput ethCallInput, BlockParameter block, string id = Constants.DEFAULT_REQUEST_ID)
            {
                return base.BuildRequest(id, ethCallInput, block);
            }
        }

    }
