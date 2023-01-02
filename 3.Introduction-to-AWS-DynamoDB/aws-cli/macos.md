# DynamoDB AWS CLI (Mac OS)

The following scripts run the AWS DynamoDB cli for Mac OS

## Creating a Table

```bash
aws dynamodb create-table \
 --table-name Music \
 --attribute-definitions \
        AttributeName=Artist,AttributeType=S \
        AttributeName=SongTitle,AttributeType=S \
 --key-schema \
        AttributeName=Artist,KeyType=HASH \
        AttributeName=SongTitle,KeyType=RANGE \
 --provisioned-throughput \
        ReadCapacityUnits=10,WriteCapacityUnits=5 \
 --endpoint-url http://localhost:8000
```

## Adding an item

```bash
aws dynamodb put-item \
    --table-name Music \
    --item \
        '{"Artist": {"S": "No One You Know"}, "SongTitle": {"S": "Call Me Today"}, "AlbumTitle": {"S": "Somewhat Famous"}}' \
    --return-consumed-capacity TOTAL 
```

## Reading an Item

```bash
aws dynamodb get-item --consistent-read \
    --table-name Music \
    --key '{ "Artist": {"S": "No One You Know"}, "SongTitle": {"S": "Call Me Today"}}'
```

## Querying Dynamo for an Item (Mac OS)

```bash
aws dynamodb query \
    --table-name Music \
    --key-condition-expression "Artist = :name" \
    --expression-attribute-values  '{":name":{"S":"No One You Know"}}'
```

## Create Global Secondary Index (Mac OS)

```bash
aws dynamodb update-table \
    --table-name Music \
    --attribute-definitions AttributeName=AlbumTitle,AttributeType=S \
    --global-secondary-index-updates \
        "[{\"Create\":{\"IndexName\": \"AlbumTitle-index\",\"KeySchema\":[{\"AttributeName\":\"AlbumTitle\",\"KeyType\":\"HASH\"}], \
        \"ProvisionedThroughput\": {\"ReadCapacityUnits\": 10, \"WriteCapacityUnits\": 5      },\"Projection\":{\"ProjectionType\":\"ALL\"}}}]"
```
