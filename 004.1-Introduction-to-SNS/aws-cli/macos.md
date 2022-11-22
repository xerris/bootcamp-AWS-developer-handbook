# SNS AWS Cli (Mac OS)

The following scripts run the AWS SNS cli for Mac OS

## List Queues

```bash
aws sns list-topics
```

## Creating a Topic

```bash
aws sns create-topic --name add-song-topic
```

## Subscribe to a Topic

```bash
aws sns subscribe \
--topic-arn arn:aws:sns:us-west-2:123456789:add-song-topic \
--protocol email \
--notification-endpoint my-email@whatever.com
```

## Create a SQS suscription

aws sns subscribe \
--topic-arn arn:aws:sns:us-east-2:859139628251:test-training-topic \
--protocol sqs \
--notification-endpoint arn:aws:sqs:us-east-2:859139628251:test-training-queue

## Publish to a Topic

```bash
aws sns publish --topic-arn arn:aws:sns:us-west-2:123456789:add-song-topic \
--message "Hello, from SNS"
```

## Delete a Topic

```bash
aws sns delete-topic \
--topic-arn arn:aws:sns:us-west-2:123456789:add-song-topic
```

