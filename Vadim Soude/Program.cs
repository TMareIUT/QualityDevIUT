using cours1;
using cours1.Exercice_3;

Library library = new Library();

try
{
    library.getDataFromFile();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Media media1;
Media media2;
Media media3;

if(Library.medias.Count != 3)
{
    media1 = new Media("test", 1, 15);
    media2 = new Media("test2", 2, 10);
    media3 = new Media("3test", 3, 12);
}
else
{
    media1 = Library.medias[0];
    media2 = Library.medias[1];
    media3 = Library.medias[2];
}

library.Add(media1);
library.Add(media2);
library.Add(media3);

Media media4 = null;

try
{
    media4 = media1 - 10;
}
catch (Exception e)
{
    Console.WriteLine(e);
}

try
{
    library.Borrow(media4, "userTest"); //Il reste un bug sur l'emprunt :(
}
catch (Exception e)
{
    Console.WriteLine(e);
}
/*
Media media5 = media4;

try
{
    media5 -= 1;
}
catch (Exception e)
{
    Console.WriteLine(e);
}


try
{
    library.Return(media5, "userTest");
}
catch (Exception e)
{
    Console.WriteLine(e);
}*/


try
{
    library.storeDataToFile();
}
catch (Exception e)
{
    Console.WriteLine(e);
}