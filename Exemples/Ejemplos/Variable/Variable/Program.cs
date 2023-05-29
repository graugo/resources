using Variable;

string str = "a";
str.ToCharArray();
char c = 'a';
int i = 0;
++i;
short s = 0;
long l = 0;
bool b = false;

DateTime dateTime = DateTime.UtcNow;
DateTime dt = new DateTime(2023,3,31);

List<int> list = new List<int>();
Dictionary<string, object> dic = new Dictionary<string, object>();

System.DayOfWeek dow = 0;
switch (dow) 
{
    case System.DayOfWeek.Monday:
        break;
}

decimal d = 0.0M;
float f = 0.0F;

var a = 0;

const int integer = 0;
var o = i + integer;