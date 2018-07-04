using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Models.Marketing;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.RequestProvider;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Marketing
{
    public class CampaignService : ICampaignService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;

<<<<<<< HEAD
=======
        private const string ApiUrlBase = "api/v1/m/campaigns";

>>>>>>> upstream/dev
        public CampaignService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<CampaignItem>> GetAllCampaignsAsync(string token)
        {
<<<<<<< HEAD
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.MarketingEndpoint);
            builder.Path = "api/v1/campaigns/user";
            string uri = builder.ToString();
=======
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayMarketingEndpoint, $"{ApiUrlBase}/user");
>>>>>>> upstream/dev

            CampaignRoot campaign = await _requestProvider.GetAsync<CampaignRoot>(uri, token);

            if (campaign?.Data != null)
            {
                _fixUriService.FixCampaignItemPictureUri(campaign?.Data);
                return campaign?.Data.ToObservableCollection();
            }

            return new ObservableCollection<CampaignItem>();
        }

        public async Task<CampaignItem> GetCampaignByIdAsync(int campaignId, string token)
        {
<<<<<<< HEAD
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.MarketingEndpoint);
            builder.Path = $"api/v1/campaigns/{campaignId}";
            string uri = builder.ToString();
=======
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayMarketingEndpoint, $"{ApiUrlBase}/{campaignId}");

>>>>>>> upstream/dev
            return await _requestProvider.GetAsync<CampaignItem>(uri, token);
        }
    }
}