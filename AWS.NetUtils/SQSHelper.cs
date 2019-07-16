using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS.Helper
{
    public class SQSHelper
    {
        public async void PushMessage(string queueUrl, string message)
        {
            AmazonSQSClient sqsClient = new AmazonSQSClient();
            var smr = new SendMessageRequest() { QueueUrl = queueUrl, MessageBody = message };
            await sqsClient.SendMessageAsync(smr);
        }

        public async void DeleteMessage(string queueUrl, string receiptHandle)
        {
            DeleteMessageRequest deleteMessageRequest = new DeleteMessageRequest();
            deleteMessageRequest.QueueUrl = queueUrl;
            deleteMessageRequest.ReceiptHandle = receiptHandle;
            var client = new AmazonSQSClient();
            await client.DeleteMessageAsync(deleteMessageRequest);
        }
    }
}