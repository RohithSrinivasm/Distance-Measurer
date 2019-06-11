const int pingPin = 7; // Trigger Pin of Ultrasonic Sensor
const int echoPin = 6; // Echo Pin of Ultrasonic Sensor
const int LED=13;
void setup() {
   Serial.begin(9600); // Starting Serial Terminal
}

void loop() {
   long duration,cm;
   pinMode(LED, OUTPUT);
   pinMode(pingPin, OUTPUT);
   digitalWrite(pingPin, LOW);
   delayMicroseconds(2);
   digitalWrite(pingPin, HIGH);
   delayMicroseconds(10);
   digitalWrite(pingPin, LOW);
   pinMode(echoPin, INPUT);
   duration = pulseIn(echoPin, HIGH);
  
   cm = microsecondsToCentimeters(duration);
   if(cm<15)
   {
    digitalWrite(LED,HIGH);
    delay(500);
    
    digitalWrite(LED,LOW);
    delay(500);
    }
   else
   digitalWrite(LED,LOW);
   
   Serial.println(cm);
   //Serial.print("cm");
  // Serial.println();
   delay(100);
}
long microsecondsToCentimeters(long microseconds) {
   return microseconds / 29 / 2;
}
