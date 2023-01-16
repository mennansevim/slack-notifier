# Slack Notifier Service

This service allows to send fourkeymetric notification as slack message

## Feature overview

*   [x] **Easy team integration** to get four key metrics
*   [x] **Send custom** slack messages by stretch kafka
*   [x] **Stay away** from offensive slack messages
*   [x] **Benchmark** fourkeymetric performance


## How can i integrate my team to get fourkeymetric statistics ?

To get fourkeymetric statistic message you should create json file under Teams folder.

Sample json file:

Peoject/Teams/globalplatforms-order-management.json

{
  "webHookUrl" : "https://hooks.slack.com/services/T0123123123123",
  "cronExpression":  "0 45 11 ? * THU", // Every Thursday on 11:45
  "teamDisplayName": "GP - Order Management",
  "pandoraGroupName": "order-management",
  "groupIds": "4468,266",
  "periodDays": 7
}

1. **webHookUrl**: Slack channel's web hook
2. **cronExpression**: Quartz cron expression (http://www.quartz-scheduler.org/documentation/quartz-2.3.0/tutorials/crontrigger.html)
3. **teamDisplayName**: Header of slack message
4. **pandoraGroupName**: Team group name for pandora navigation link (https://pandora.trendyol.com/catalog/default/group/order-management)
5. **groupIds**: GroupIds to follow fourkeymetrics
6. **periodDays**: Period day count to calculate fourkeymetrics. For example you enter periodsDays is 7 and cron job works every Thursday at 12:00, 
	             so the service show metrics from between now().addDays(-7) and now(). 


## Why should I use this?

This service helps to you to benchmark your team's fourkeymetrics performance.

## Sample Slack Message

<img width="454" alt="image" src="https://user-images.githubusercontent.com/40278697/212184396-cd683b99-1ecb-470b-aec1-503966f0522a.png">

Change Fail Percentage % 0     %0     :heavy_minus_sign:
# slack-notifier
