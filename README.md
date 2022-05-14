# SCP Chat

* **Allows SCPs to use the console to send messages to each other**

| ❗  Needs [AdvancedHints](https://github.com/BuildBoy12/AdvancedHints/releases/latest) to be installed in the `Exiled/Plugins` directory to work |
|-------------------------------------------------------------------------------------------------------------------------------------------------|
## Configuration

| Config setting | Default           | Description                                                     |
|----------------|-------------------|-----------------------------------------------------------------|
| is_enabled     | true              | Whether the plugin is enabled or not                            |
| aliases        | "c", "chat", "sc" | Aliases for the chat command                                    |
| message_format | "{0} {1}: {2}"    | Format for the message to be sent. SCP {0} Name {1} Message {2} |
 | hint_duration  | 7                 | How long messages are displayed for in seconds.                 |
 | history_length | 1                 | How many messages to show in the chat history.                  |

```diff
- s
```