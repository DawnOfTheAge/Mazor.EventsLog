using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.GIS.Bing
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Policy;
    using System.Text;
    using System.Threading.Tasks;

    public class LocationService
    {
        #region Data Members

        private string RestUrl;
        private string BingMapsApiKey;
        private string CountryRegion;
        private string Locality;

        #endregion

        #region Data Types 

        public class Point
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

        public class Address
        {
            public string addressLine { get; set; }
            public string adminDistrict { get; set; }
            public string countryRegion { get; set; }
            public string formattedAddress { get; set; }
            public string locality { get; set; }
            public string postalCode { get; set; }
        }

        public class GeocodePoint
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
            public string calculationMethod { get; set; }
            public List<string> usageTypes { get; set; }
        }

        public class Resource
        {
            public string __type { get; set; }
            public List<double> bbox { get; set; }
            public string name { get; set; }
            public Point point { get; set; }
            public Address address { get; set; }
            public string confidence { get; set; }
            public string entityType { get; set; }
            public List<GeocodePoint> geocodePoints { get; set; }
            public List<string> matchCodes { get; set; }
        }

        public class ResourceSet
        {
            public int estimatedTotal { get; set; }
            public List<Resource> resources { get; set; }
        }

        public class AddressLocationInformation
        {
            public string authenticationResultCode { get; set; }
            public string brandLogoUri { get; set; }
            public string copyright { get; set; }
            public List<ResourceSet> resourceSets { get; set; }
            public int statusCode { get; set; }
            public string statusDescription { get; set; }
            public string traceId { get; set; }
        }

        #endregion

        public LocationService(string restUrl, string bingMapsApiKey, string countryRegion, string locality)
        {
            RestUrl = restUrl;
            BingMapsApiKey = bingMapsApiKey;
            CountryRegion = countryRegion;
            Locality = locality;
        }

        public bool AddressToLongtitudeLatitude(string addressLine, out double longtitude, out double latitude, out string result)
        {
            string url;
            string response;

            result = string.Empty;

            longtitude = 0;
            latitude = 0;

            try
            {
                if (!CreateUrl(RestUrl, BingMapsApiKey, CountryRegion, Locality, addressLine, out url, out result))
                {
                    return false;
                }

                if (!RestGetCommand(url, out int httpStatusCode, out response, out result))
                {
                    return false;
                }

                AddressLocationInformation addressLocationInformation = JsonConvert.DeserializeObject<AddressLocationInformation>(response);

                if (addressLocationInformation == null)
                {
                    result = $"Address {addressLine} Not Found";

                    return false;
                }

                longtitude = addressLocationInformation.resourceSets[0].resources[0].geocodePoints[0].coordinates[0];
                latitude = addressLocationInformation.resourceSets[0].resources[0].geocodePoints[0].coordinates[1];

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateUrl(string mainUrl,
                              string bingMapsApiKey,
                              string countryRegion,
                              string locality,
                              string addressLine,
                              out string fullUrl,
                              out string result)
        {
            result = string.Empty;
            fullUrl = string.Empty;

            try
            {
                fullUrl = $"{mainUrl}?CountryRegion={countryRegion}&Locality={locality}&AddressLine={addressLine}&Key={bingMapsApiKey}";

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool RestGetCommand(string url, out int httpStatusCode, out string response, out string result)
        {
            result = string.Empty;
            response = string.Empty;

            httpStatusCode = -1;

            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    result = "URL Is Null Or Empty";

                    return false;
                }

                HttpClient httpClient = new HttpClient();

                HttpResponseMessage httpResponse = httpClient.GetAsync(url).Result;

                httpStatusCode = (int)httpResponse.StatusCode;
                response = httpResponse.Content.ReadAsStringAsync().Result;

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                response = e.Message + Environment.NewLine + e.InnerException;
                result = e.Message;

                return false;
            }
        }
    }
}
