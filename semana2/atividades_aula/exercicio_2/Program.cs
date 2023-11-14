#region exercicio_1
for(int i=0;i<=30;i++){
    if(i%3 == 0){
        Console.WriteLine(i);
    }else if(i%4 == 0){
        Console.WriteLine(i);
    }
}
#endregion

#region exercicio_2
int n;
int x=1, y=0, z=0;
n = 10;

for (int i = 0; i < n; i++)
{
    z = x + y;
    if(z > 100){
        break;
    }
    Console.WriteLine(z);
    y = x;
    x = z;
}
Console.ReadLine();

#endregion

#region exercicio_3
int n = 7;

for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write(i * j + " ");
    }
    Console.WriteLine();
}

#endregion
