
# Arduino IoT Projects

## Description

This repository contains projects that involve IoT solutions using Arduino. Specifically, it includes a project aimed at controlling the temperature of a warehouse where temperature-sensitive medicines are stored. The project utilizes an Arduino NODEMCU to communicate with a web service that stores temperature data and displays it on a dashboard.

## Requirements

- Arduino IDE
- NODEMCU board
- Temperature sensor (e.g., DHT11 or DHT22)
- Internet connection for IoT functionality

## Mode of Use

1. Clone the repository:
   ```bash
   git clone https://github.com/ferrerallan/Arduino.git
   ```
2. Navigate to the project directory:
   ```bash
   cd Arduino
   ```
3. Open the Arduino IDE and load the `.ino` file from the project directory.
4. Connect the NODEMCU board to your computer.
5. Upload the code to the NODEMCU board.
6. Ensure the board is connected to the temperature sensor and configured to connect to your Wi-Fi network.

## Use Case

This project can be used as a reference for developing IoT applications that require real-time monitoring and control of environmental conditions. It is particularly useful for:

- Warehouses storing temperature-sensitive goods
- Pharmaceutical storage and distribution centers
- Any facility requiring precise temperature control

## Example of Use

### Reading Temperature Data

The code snippet below demonstrates how to read temperature data from a DHT sensor and send it to a web service:

```cpp
#include <ESP8266WiFi.h>
#include <DHT.h>

#define DHTPIN D4
#define DHTTYPE DHT11

DHT dht(DHTPIN, DHTTYPE);

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  dht.begin();
}

void loop() {
  float temperature = dht.readTemperature();
  if (isnan(temperature)) {
    return;
  }

  WiFiClient client;
  if (client.connect(server, 80)) {
    String postStr = "temperature=" + String(temperature);
    client.print("POST /temperature HTTP/1.1
");
    client.print("Content-Length: " + String(postStr.length()) + "

");
    client.print(postStr);
  }
  delay(60000); // Send data every 60 seconds
}
```

## License

This project is licensed under the MIT License.
