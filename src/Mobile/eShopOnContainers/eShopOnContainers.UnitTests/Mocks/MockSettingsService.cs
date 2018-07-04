using eShopOnContainers.Core.Services.Settings;
using System;

namespace eShopOnContainers.UnitTests.Mocks
{
    public class MockSettingsService : ISettingsService
    {
<<<<<<< HEAD
        string _accessTokenDefault = string.Empty;
        string _idTokenDefault = string.Empty;
        bool _useMocksDefault = true;
        string _urlBaseDefault = "https://13.88.8.119";
        bool _useFakeLocationDefault = false;
        bool _allowGpsLocationDefault = false;
        double _fakeLatitudeDefault = 47.604610d;
        double _fakeLongitudeDefault = -122.315752d;
=======
        IDictionary<string, object> _settings = new Dictionary<string, object>();

        const string AccessToken = "access_token";
        const string IdToken = "id_token";
        const string IdUseMocks = "use_mocks";
        const string IdIdentityBase = "url_base";
        const string IdGatewayMarketingBase = "url_marketing";
        const string IdGatewayShoppingBase = "url_shopping";
        const string IdUseFakeLocation = "use_fake_location";
        const string IdLatitude = "latitude";
        const string IdLongitude = "longitude";
        const string IdAllowGpsLocation = "allow_gps_location";
        readonly string AccessTokenDefault = string.Empty;
        readonly string IdTokenDefault = string.Empty;
        readonly bool UseMocksDefault = true;
        readonly bool UseFakeLocationDefault = false;
        readonly bool AllowGpsLocationDefault = false;
        readonly double FakeLatitudeDefault = 47.604610d;
        readonly double FakeLongitudeDefault = -122.315752d;
        readonly string UrlIdentityDefault = "https://13.88.8.119";
        readonly string UrlGatewayMarketingDefault = "https://13.88.8.119";
        readonly string UrlGatewayShoppingDefault = "https://13.88.8.119";
>>>>>>> upstream/dev

        public string AuthAccessToken
        {
            get { return _accessTokenDefault; }
            set { _accessTokenDefault = value; }
        }

        public string AuthIdToken
        {
            get { return _idTokenDefault; }
            set { _idTokenDefault = value; }
        }

        public bool UseMocks
        {
            get { return _useMocksDefault; }
            set { _useMocksDefault = value; }
        }

        public string IdentityEndpointBase
        {
<<<<<<< HEAD
            get { return _urlBaseDefault; }
            set { _urlBaseDefault = value; }
=======
            get => GetValueOrDefault(IdIdentityBase, UrlIdentityDefault);
            set => AddOrUpdateValue(IdIdentityBase, value);
        }

        public string GatewayShoppingEndpointBase
        {
            get => GetValueOrDefault(IdGatewayShoppingBase, UrlGatewayShoppingDefault);
            set => AddOrUpdateValue(IdGatewayShoppingBase, value);
        }

        public string GatewayMarketingEndpointBase
        {
            get => GetValueOrDefault(IdGatewayMarketingBase, UrlGatewayMarketingDefault);
            set => AddOrUpdateValue(IdGatewayMarketingBase, value);
>>>>>>> upstream/dev
        }

        public bool UseFakeLocation
        {
            get { return _useFakeLocationDefault; }
            set { _useFakeLocationDefault = value; }
        }

        public string Latitude
        {
            get { return _fakeLatitudeDefault.ToString(); }
            set { _fakeLatitudeDefault = Convert.ToDouble(value); }
        }

        public string Longitude
        {
            get { return _fakeLongitudeDefault.ToString(); }
            set { _fakeLongitudeDefault = Convert.ToDouble(value); }
        }

        public bool AllowGpsLocation
        {
            get { return _allowGpsLocationDefault; }
            set { _allowGpsLocationDefault = value; }
        }
    }
}
