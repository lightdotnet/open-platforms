using Light.Contracts;
using Light.Grab.GrabMart.Models;
using System.Threading.Tasks;

namespace Light.Grab.GrabMart
{
    public interface ISelfServeActivation
    {
        /// <summary>
        /// Note:
        ///     Please setup items for your store menu before calling this API.
        /// </summary>
        Task<Result<SelfServeActivationResponse>> GetActivationUrl(string partnerMerchantId);
    }
}
