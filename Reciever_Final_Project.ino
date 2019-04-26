// 433MHz RF Module Receiver is used for wireless communication
// Include RadioHead Amplitude Shift Keying Library
#include <RH_ASK.h>
// Include dependant SPI Library 
#include <SPI.h>
//include Dynamixel Motor Library
#include <DynamixelSerial3.h>

// Create Amplitude Shift Keying Object
RH_ASK rf_driver;
int x =200; //adjust the speed of Dynamixel motor
void setup()
{
    // Initialize ASK Object
    rf_driver.init();
    // Setup Serial Monitor
    Serial.begin(9600);
    Dynamixel.begin(1000000, 2);  // Inicialize the servo at 1Mbps and Pin Control 2
    delay(1000);
}

void loop()
{
    // Set buffer to size of expected message
    uint8_t buf[6];
    uint8_t buflen = sizeof(buf);
    // Check if received packet is correct size
    if (rf_driver.recv(buf, &buflen))
    { Serial.print("Message Received: ");
      for (int i=0;i<sizeof(buf);i++){
        Serial.print(char(buf[i]));
        }
        Serial.println("");
      if(char(buf[5])=='1')//check if the 5th element in arrays (mode 1) is 1 then
      {//put hands down
        Dynamixel.moveSpeed(1, 214, x);
        Dynamixel.moveSpeed(2, 825, x);
        Dynamixel.moveSpeed(3, 221, x);
        Dynamixel.moveSpeed(4, 778, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 556, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      else if(char(buf[5])=='2')//check if the 5th element in arrays (mode 2) is 2 then
      {//stretching hands
        Dynamixel.moveSpeed(1, 214, x);
        Dynamixel.moveSpeed(2, 825, x);
        Dynamixel.moveSpeed(3, 519, x);
        Dynamixel.moveSpeed(4, 505, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      
      else if(char(buf[5])=='3')
      {//raise hands up
        Dynamixel.moveSpeed(1, 214, x);
        Dynamixel.moveSpeed(2, 825, x);
        Dynamixel.moveSpeed(3, 756, x);
        Dynamixel.moveSpeed(4, 239, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      if(char(buf[5])=='4')
      {//stretching hands forward
        Dynamixel.moveSpeed(1, 518, x);
        Dynamixel.moveSpeed(2, 503, x);
        Dynamixel.moveSpeed(3, 221, x);
        Dynamixel.moveSpeed(4, 778, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      if(char(buf[5])=='5')//tangan setengah diturunkan ke bawah
      {
        Dynamixel.moveSpeed(1, 214, x);
        Dynamixel.moveSpeed(2, 825, x);
        Dynamixel.moveSpeed(3, 387, x);
        Dynamixel.moveSpeed(4, 672, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      if(char(buf[5])=='6')
      {//raise hands up half
        Dynamixel.moveSpeed(1, 214, x);
        Dynamixel.moveSpeed(2, 825, x);
        Dynamixel.moveSpeed(3, 633, x);
        Dynamixel.moveSpeed(4, 361, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      if(char(buf[5])=='7')
      {//straighten hands forward
        Dynamixel.moveSpeed(1, 518, x);
        Dynamixel.moveSpeed(2, 503, x);
        Dynamixel.moveSpeed(3, 333, x);
        Dynamixel.moveSpeed(4, 653, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      if(char(buf[5])=='8')
      {//raise right hand and stretching left hand
        Dynamixel.moveSpeed(1, 214, x);
        Dynamixel.moveSpeed(2, 825, x);
        Dynamixel.moveSpeed(3, 519, x);
        Dynamixel.moveSpeed(4, 239, x);
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
      if(char(buf[5])=='9')
      {//raise left hand and stretching right hand
        Dynamixel.moveSpeed(1, 214, x);
        Dynamixel.moveSpeed(2, 825, x);
        Dynamixel.moveSpeed(3, 756, x);//786
        Dynamixel.moveSpeed(4, 505, x);//209
        Dynamixel.moveSpeed(5, 515, x);
        Dynamixel.moveSpeed(6, 515, x);
        Dynamixel.moveSpeed(7, 511, x);
        Dynamixel.moveSpeed(8, 486, x);
        Dynamixel.moveSpeed(9, 512, x);
        Dynamixel.moveSpeed(10, 514, x);
        Dynamixel.moveSpeed(11, 361, x);
        Dynamixel.moveSpeed(12, 659, x);
        Dynamixel.moveSpeed(13, 71, x);
        Dynamixel.moveSpeed(14, 973, x);
        Dynamixel.moveSpeed(15, 843, x);
        Dynamixel.moveSpeed(16, 179, x);
        Dynamixel.moveSpeed(17, 517, x);
        Dynamixel.moveSpeed(18, 502, x);
        delay(1000);
      }
    }
}
