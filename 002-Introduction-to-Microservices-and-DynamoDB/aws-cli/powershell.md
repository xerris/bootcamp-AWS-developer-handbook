# DynamoDB AWS Cli (PowerShell)

The following scripts run the AWS DynamoDB cli for PowerShell

## Creating a Table

```powershell
aws dynamodb create-table `
 --table-name Music `
 --attribute-definitions `
        AttributeName=Artist,AttributeType=S `
        AttributeName=SongTitle,AttributeType=S `
 --key-schema `
        AttributeName=Artist,KeyType=HASH `
        AttributeName=SongTitle,KeyType=RANGE `
 --provisioned-throughput `
        ReadCapacityUnits=10,WriteCapacityUnits=5
```

## Adding an item

```powershell
aws dynamodb put-item `
    --table-name Music `
    --item `
        "{\`"Artist\`": {\`"S\`": \`"No One You Know\`"}, \`"SongTitle\`": {\`"S\`": \`"Call Me Today\`"}, \`"AlbumTitle\`": {\`"S\`": \`"Somewhat Famous\`"}}" `
    --return-consumed-capacity TOTAL 
```

## Reading an Item

```powershell
aws dynamodb get-item --consistent-read `
    --table-name Music `
    --key "{ \`"Artist\`": {\`"S\`": \`"No One You Know\`"}, \`"SongTitle\`": {\`"S\`": \`"Call Me Today\`"}}”
```

## Querying Dynamo for an Item

```powershell
aws dynamodb query ` --table-name Music `  --key-condition-expression "Artist = :name" ` --expression-attribute-values  "{ \`":name\`":{\`"S\`":\`"No One You Know\`"}}"
```

## Create Global Secondary Index

```powershell
aws dynamodb update-table `
    --table-name Music `
    --attribute-definitions AttributeName=AlbumTitle,AttributeType=S `
    --global-secondary-index-updates `
        "[{\`"Create\`":{\`"IndexName\`": \`"AlbumTitle-index\`",\`"KeySchema\`":[{\`"AttributeName\`":\`"AlbumTitle\`",\`"KeyType\`":\`"HASH\`"}], `
        \`"ProvisionedThroughput\` ": {\`"ReadCapacityUnits\`": 10, \`"WriteCapacityUnits\`": 5      },\`"Projection\`":{\`"ProjectionType\`":\`"ALL\`"}}}]"
```
