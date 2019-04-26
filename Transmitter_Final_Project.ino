// 433MHz RF Module Transmitter is used for wireless communication
// Include RadioHead Amplitude Shift Keying Library
#include <RH_ASK.h>
// Include dependant SPI Library 
#include <SPI.h> 

// Create Amplitude Shift Keying Object
RH_ASK rf_driver;

void setup()
{
    // Initialize ASK Object
    rf_driver.init();
    Serial.begin(9600);
}

void loop()
{   
    
        char NS = Serial.read(); //read data sent by Visual Studio
        if (NS == '1')//if the data is 1 then robot will put its hands down
        {
          char *msg = "mode 1"; //the string that will be sent wireless to the other arduino 
          rf_driver.send((uint8_t *)msg, strlen(msg)); //send "mode 1"
          rf_driver.waitPacketSent();
          //delay(1000); you can put the delay if you want the robot reacts slowly
        }
        else if (NS == '2')//if the data is 2 then robot will stretch its hand
        {
          char *msg = "mode 2";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
        else if (NS == '3')//if the data is 3 then robot will raise its hand
          char *msg = "mode 3";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
        else if (NS == '4')//straighten hands forward(put hand out)
        {
          char *msg = "mode 4";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
        else if (NS == '5')//put hands down half(range between stretching hand and putting hand down)
        {
          char *msg = "mode 5";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
        else if (NS == '6')//raise hands up half(range between stretching hand and raising hand up)
        {
          char *msg = "mode 6";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
        else if (NS == '7')//straighten hands forward half(between stretching hand and straighten hand forward)
        {
          char *msg = "mode 7";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
        else if (NS == '8')//raise right hand and stretching left hand
        {
          char *msg = "mode 8";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
        else if (NS == '9')//raise left hand and stretching right hand
        {
          char *msg = "mode 9";
          rf_driver.send((uint8_t *)msg, strlen(msg));
          rf_driver.waitPacketSent();
          //delay(1000);
        }
      
      
}


