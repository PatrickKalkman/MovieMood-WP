using System;
using System.Net;

using Caliburn.Micro;

using Newtonsoft.Json;

namespace MovieMood.Netflix
{
    public class NetflixRoulette
    {
        private readonly IEventAggregator eventAggregator;

        public const string API_URL = "http://netflixroulette.net/api/api.php?";

        public NetflixRoulette(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void CreateRequest(string title)
        {
            CreateRequest(title, 0);
        }

        public void CreateRequest(string title, int year)
        {
            CreateRequest(new RouletteRequest
            {
                Title = title,
                Year = year
            });
        }

        public void CreateRequest(RouletteRequest requestData)
        {
            try
            {
                var client = new WebClient();
                client.DownloadStringCompleted += ClientOnDownloadStringCompleted;
                client.DownloadStringAsync(new Uri(requestData.ApiUrl));
            }
            catch (Exception exception)
            {
                throw new RouletteRequestException("{0} {1}", exception.Message, requestData.ToString());
            }
        }

        private void ClientOnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                var response = new RouletteResponse();
                response.error = true;
                PublishMessage(response);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(args.Result))
                {
                    var response = JsonConvert.DeserializeObject<RouletteResponse>(args.Result);
                    PublishMessage(response);
                }
            }

        }

        private void PublishMessage(RouletteResponse response)
        {
            eventAggregator.Publish(response);
        }
    }
}
