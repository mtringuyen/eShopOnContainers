using System;
using System.Threading.Tasks;
using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Services.RequestProvider;

namespace eShopOnContainers.Core.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "api/v1/l/locations";

        public LocationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task UpdateUserLocation(eShopOnContainers.Core.Models.Location.Location newLocReq, string token)
        {
<<<<<<< HEAD
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.LocationEndpoint);
            builder.Path = "api/v1/locations";
            string uri = builder.ToString();
=======
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayMarketingEndpoint, ApiUrlBase);

>>>>>>> upstream/dev
            await _requestProvider.PostAsync(uri, newLocReq, token);
        }
    }
}