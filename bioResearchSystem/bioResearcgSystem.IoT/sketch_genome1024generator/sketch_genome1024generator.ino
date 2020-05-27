 int const N = 4;
 int const chunckSize = 2048;
 char const NUCLEOBASE[N]  = {'a','c','g','t'};
 
void setup() {
  Serial.begin(9600);
}
void loop() {
  String data = "";
  while(data.length()!= chunckSize){
        data+= NUCLEOBASE[random(0,N-1)];
    }
    Serial.println(data);
}
