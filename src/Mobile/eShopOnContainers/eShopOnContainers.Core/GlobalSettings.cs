using System;

namespace eShopOnContainers.Core
{
    public class GlobalSetting
    {
        public const string AzureTag = "Azure";
        public const string MockTag = "Mock";
        public const string DefaultEndpoint = "http://13.88.8.119";

        private string _baseIdentityEndpoint;
        private string _baseGatewayShoppingEndpoint;
        private string _baseGatewayMarketingEndpoint;

        public GlobalSetting()
        {
            AuthToken = "INSERT AUTHENTICATION TOKEN";

            BaseIdentityEndpoint = DefaultEndpoint;
            BaseGatewayShoppingEndpoint = DefaultEndpoint;
            BaseGatewayMarketingEndpoint = DefaultEndpoint;
        }

        public static GlobalSetting Instance { get; } = new GlobalSetting();

        public string BaseIdentityEndpoint
        {
            get { return _baseIdentityEndpoint; }
            set
            {
                _baseIdentityEndpoint = value;
                UpdateEndpoint(_baseIdentityEndpoint);
            }
        }

        public string BaseGatewayShoppingEndpoint
        {
            get { return _baseGatewayShoppingEndpoint; }
            set
            {
                _baseGatewayShoppingEndpoint = value;
                UpdateGatewayShoppingEndpoint(_baseGatewayShoppingEndpoint);
            }
        }

        public string BaseGatewayMarketingEndpoint
        {
            get { return _baseGatewayMarketingEndpoint; }
            set
            {
                _baseGatewayMarketingEndpoint = value;
                UpdateGatewayMarketingEndpoint(_baseGatewayMarketingEndpoint);
            }
        }

        public string ClientId { get { return "xamarin"; } }

        public string ClientSecret { get { return "secret"; } }

        public string AuthToken { get; set; }

        public string RegisterWebsite { get; set; }

<<<<<<< HEAD
        public string CatalogEndpoint { get; set; }

        public string OrdersEndpoint { get; set; }

        public string BasketEndpoint { get; set; }

        public string IdentityEndpoint { get; set; }
=======
        public string AuthorizeEndpoint { get; set; }
>>>>>>> upstream/dev

        public string LocationEndpoint { get; set; }

        public string MarketingEndpoint { get; set; }

        public string UserInfoEndpoint { get; set; }

        public string TokenEndpoint { get; set; }

        public string LogoutEndpoint { get; set; }

        public string Callback { get; set; }

        public string LogoutCallback { get; set; }

        public string GatewayShoppingEndpoint { get; set; }

        public string GatewayMarketingEndpoint { get; set; }

        private void UpdateEndpoint(string endpoint)
        {
<<<<<<< HEAD
            RegisterWebsite = $"{baseEndpoint}:5105/Account/Register";
            CatalogEndpoint = $"{baseEndpoint}:5101";
            OrdersEndpoint = $"{baseEndpoint}:5102";
            BasketEndpoint = $"{baseEndpoint}:5103";
            IdentityEndpoint = $"{baseEndpoint}:5105/connect/authorize";
            UserInfoEndpoint = $"{baseEndpoint}:5105/connect/userinfo";
            TokenEndpoint = $"{baseEndpoint}:5105/connect/token";
            LogoutEndpoint = $"{baseEndpoint}:5105/connect/endsession";
            IdentityCallback = $"{baseEndpoint}:5105/xamarincallback";
            LogoutCallback = $"{baseEndpoint}:5105/Account/Redirecting";
            LocationEndpoint = $"{baseEndpoint}:5109";
            MarketingEndpoint = $"{baseEndpoint}:5110";
=======
            RegisterWebsite = $"{endpoint}/Account/Register";
            LogoutCallback = $"{endpoint}/Account/Redirecting";

            var connectBaseEndpoint = $"{endpoint}/connect";
            AuthorizeEndpoint = $"{connectBaseEndpoint}/authorize";
            UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
            TokenEndpoint = $"{connectBaseEndpoint}/token";
            LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

            var baseUri = ExtractBaseUri(endpoint);
            Callback = $"{baseUri}/xamarincallback";
        }

        private void UpdateGatewayShoppingEndpoint(string endpoint)
        {
            GatewayShoppingEndpoint = $"{endpoint}";
        }

        private void UpdateGatewayMarketingEndpoint(string endpoint)
        {
            GatewayMarketingEndpoint = $"{endpoint}";
        }

        private string ExtractBaseUri(string endpoint)
        {
            var uri = new Uri(endpoint);
            var baseUri = uri.GetLeftPart(System.UriPartial.Authority);

            return baseUri;
>>>>>>> upstream/dev
        }
    }
}