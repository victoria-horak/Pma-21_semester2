// See https://aka.ms/new-console-template for more information
using CreationalPatterns.Factory;
using CreationalPatterns.Toys;

Console.WriteLine("Hello, World!");

var toys = new AnimalToy[4];
IToyFactory toyFactory = new WoodenToysFactory();
var woodenCat = toyFactory.GetCat();
toys[0] = woodenCat;

var woodenBear = toyFactory.GetBear();
toys[1] = woodenBear;
//woodenBear.Name = "Very wooden bear";
//Console.WriteLine(woodenBear.Name);

toyFactory = new TeddyToysFactory();    
var teddyCat = toyFactory.GetCat();
toys[2] = teddyCat;

var teddyBear = toyFactory.GetBear();
toys[3] = teddyBear;

for(int i = 0; i < 4; i++)
{
    toys[i].PrintYourself();
}

