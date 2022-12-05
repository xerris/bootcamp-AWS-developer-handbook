# SNS AWS Cli (PowerShell)

The following scripts run the AWS SNS cli for PowerShell

## Create Queue
<!-- This command creates a queue named  test-training-queue-->

aws sqs create-queue --queue-name test-training-queue

<!-- Output : {
    "QueueUrl": "https://sqs.us-east-2.amazonaws.com/859139628251/test-training-queue"
} -->

## Create Topic

<!-- This command creates SNS Topic test-training-topic -->

aws sns create-topic --name test-training-topic --output text

<!-- Output: arn:aws:sns:us-east-2:859139628251:test-training-topic -->

## Get Queue Url - to create the subscription

 aws sqs get-queue-attributes --queue-url https://sqs.us-east-2.amazonaws.com/859139628251/test-training-queue --attribute-names QueueArn

<!-- Output: {
    "Attributes": {
        "QueueArn": "arn:aws:sqs:us-east-2:859139628251:test-training-queue"
    }
} -->

## Create a SQS suscription

aws sns subscribe --topic-arn arn:aws:sns:us-east-2:859139628251:test-training-topic --protocol sqs --notification-endpoint arn:aws:sqs:us-east-2:859139628251:test-training-queue

<!-- topic-arn: sns topic arn
protocol: sqs - for queue subscription
notification-endpoint: Queue's ARN 
Output: {
    "SubscriptionArn": "arn:aws:sns:us-east-2:859139628251:test-training-topic:42296ce6-2000-41fc-bdc3-59b672951f62"
} -->

## List sns subscriptions

aws sns list-subscriptions

## Publish a message to the queue 

aws sns publish --topic-arn arn:aws:sns:us-east-2:859139628251:test-training-topic --message "Hello World!"

## Receive SQS message 
aws sqs receive-message --queue-url https://sqs.us-east-2.amazonaws.com/859139628251/test-training-queue

## Unsubscribe the topic

aws sns unsubscribe --subscription-arn arn:aws:sns:us-east-2:859139628251:test-training-topic:f43287c9-882c-49c0-a824-55ceb012337c

<!-- subscription-arn: output from the suscribe command -->

## delete topic

aws sns delete-topic --topic-arn arn:aws:sns:us-east-2:859139628251:test-training-topic

## delete queue

 aws sqs delete-queue --queue-url https://sqs.us-east-2.amazonaws.com/859139628251/test-training-queue