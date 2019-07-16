using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Helper
{
    public class SNSHelper
    {
        public static async Task<PublishResponse> SNSPublishMessage(string topicArn, string message)
        {
            var client = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.USEast1);
            var request = new PublishRequest
            {
                TopicArn = topicArn,
                Message = message
            };

            return await client.PublishAsync(request);
        }
    }
}
